using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using realEstateApi.Context;
using realEstateApi.Models;

namespace realEstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PricesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Price>>> GetPrices()
        {
          if (_context.Prices == null)
          {
              return NotFound();
          }
            return await _context.Prices.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Price>> GetPrice(int id)
        {
          if (_context.Prices == null)
          {
              return NotFound();
          }
            var price = await _context.Prices.FindAsync(id);

            if (price == null)
            {
                return NotFound();
            }

            return price;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrice(int id, Price price)
        {
            if (id != price.Id)
            {
                return BadRequest();
            }

            _context.Entry(price).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceExists(id))
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
        public async Task<ActionResult<Price>> PostPrice(Price price)
        {
          if (_context.Prices == null)
          {
              return Problem("Entity set 'AppDbContext.Prices'  is null.");
          }
            _context.Prices.Add(price);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrice", new { id = price.Id }, price);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrice(int id)
        {
            if (_context.Prices == null)
            {
                return NotFound();
            }
            var price = await _context.Prices.FindAsync(id);
            if (price == null)
            {
                return NotFound();
            }

            _context.Prices.Remove(price);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PriceExists(int id)
        {
            return (_context.Prices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
