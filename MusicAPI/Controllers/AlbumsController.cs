using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPI.Data;
using MusicAPI.Models;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public AlbumsController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Album album)
        {
            await _context.Albums.AddAsync(album);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbums()
        {
            var albums = await (from album in _context.Albums
                                 select new
                                 {
                                     Id = album.Id,
                                     Name = album.Name,
                                     ImageUrl = album.ImageUrl
                                 }).ToListAsync();
            return Ok(albums);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> AlbumDetails(int albumId)
        {
            var albumDetails = await _context.Albums.Where(a => a.Id == albumId).Include(n => n.Songs).ToListAsync();
            return Ok(albumDetails);
        }
    }
}
