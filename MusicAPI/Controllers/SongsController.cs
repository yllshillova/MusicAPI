using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPI.Data;
using MusicAPI.Models;
using System.Linq;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public SongsController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Song song)
        {
            song.UploadedDate = DateTime.Now;
            await _context.Songs.AddAsync(song);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSongs(int? pageNumber, int? pageSize)
        {
            int currentPageNumber = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 5;
            var songs = await (from song in _context.Songs
                                select new
                                {
                                    Id = song.Id,
                                    Ttile = song.Title,
                                    Duration = song.Duration,
                                    Image = song.ImageURL
                                }).ToListAsync();
            return Ok(songs.Skip((currentPageNumber - 1)* currentPageSize).Take(currentPageSize));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FeaturedSongs()
        {
            var songs = await (from song in _context.Songs
                               where song.IsFeatured == true
                               select new
                               {
                                   Id = song.Id,
                                   Ttile = song.Title,
                                   Duration = song.Duration,
                                   Image = song.ImageURL
                               }).ToListAsync();
            return Ok(songs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> NewSongs()
        {
            var songs = await (from song in _context.Songs
                               orderby song.UploadedDate descending
                               select new
                               {
                                   Id = song.Id,
                                   Ttile = song.Title,
                                   Duration = song.Duration,
                                   Image = song.ImageURL
                               }).Take(15).ToListAsync();
            return Ok(songs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> SearchSongs(string query)
        {
            var songs = await (from song in _context.Songs
                               where song.Title.StartsWith(query)
                               select new
                               {
                                   Id = song.Id,
                                   Ttile = song.Title,
                                   Duration = song.Duration,
                                   Image = song.ImageURL
                               }).Take(15).ToListAsync();
            return Ok(songs);
        }
    }
}
