using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using realEstateApi.Context;
using realEstateApi.Models;

namespace realEstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AmenitiesController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenities>>> GetAmenities()
        {
          if (_context.Amenities == null)
          {
              return NotFound();
          }
            return await _context.Amenities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Amenities>> GetAmenities(int id)
        {
          if (_context.Amenities == null)
          {
              return NotFound();
          }
            var amenities = await _context.Amenities.FindAsync(id);

            if (amenities == null)
            {
                return NotFound();
            }

            return amenities;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenities(int id, Amenities amenities)
        {
            if (id != amenities.Id)
            {
                return BadRequest();
            }

            _context.Entry(amenities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmenitiesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Amenities>> PostAmenities(Amenities amenities)
        {
          if (_context.Amenities == null)
          {
              return Problem(" is null.");
          }
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAmenities", new { id = amenities.Id }, amenities);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenities(int id)
        {
            if (_context.Amenities == null)
            {
                return NotFound();
            }
            var amenities = await _context.Amenities.FindAsync(id);
            if (amenities == null)
            {
                return NotFound();
            }

            _context.Amenities.Remove(amenities);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AmenitiesExists(int id)
        {
            return (_context.Amenities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
