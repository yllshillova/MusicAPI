using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPI.Data;
using MusicAPI.Models;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ArtistsController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Artist artist)
        {
            await _context.Artists.AddAsync(artist);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetArtists(int? pageNumber, int? pageSize)
        {
            int currentPageNumber = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 5;
            var artists = await (from artist in _context.Artists
            select new
            {
                Id = artist.Id,
                Name = artist.Name,
                ImageUrl = artist.ImageUrl
            }).ToListAsync();
            return Ok(artists.Skip((currentPageNumber - 1) * currentPageSize).Take(currentPageSize));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ArtistDetails(int artistId)
        {
            var artistDetails = await _context.Artists.Where(a=> a.Id == artistId).Include(n => n.Songs).ToListAsync();
            return Ok(artistDetails);
        }


    }
}
