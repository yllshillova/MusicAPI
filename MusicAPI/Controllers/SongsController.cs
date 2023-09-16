using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPI.Data;
using MusicAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/<SongsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Songs.ToListAsync());
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound("No record found against this Id");
            }
            return Ok(song);
        }

        //Get api/songs/test/5
        [HttpGet("[action]/{id}")]
        public int Test(int id)
        {
            return id;
        }


        // POST api/<SongsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Song song)
        {
            await _context.Songs.AddAsync(song);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Song songObj)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound("No record found against this Id");
            }
            else
            {
                song.Title = songObj.Title;
                song.Language = songObj.Language;
                song.Duration = songObj.Duration;
                song.ImageURL = songObj.ImageURL;
                await _context.SaveChangesAsync();
                return Ok("Record Updated Successfully");
            }

        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound("No record found against this Id");
            }
            else
            {
                _context.Songs.Remove(song);
                await _context.SaveChangesAsync();
                return Ok("Record deleted");
            }
        }
    }
}
