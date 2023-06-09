using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using realEstateApi.Context;
using realEstateApi.Models;

namespace realEstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InquiryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InquiryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inquiry>>> GetInquiries()
        {
          if (_context.Inquiries == null)
          {
              return NotFound();
          }
            return await _context.Inquiries.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inquiry>> GetInquiry(int id)
        {
          if (_context.Inquiries == null)
          {
              return NotFound();
          }
            var inquiry = await _context.Inquiries.FindAsync(id);

            if (inquiry == null)
            {
                return NotFound();
            }

            return inquiry;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInquiry(int id, Inquiry inquiry)
        {
            if (id != inquiry.Id)
            {
                return BadRequest();
            }

            _context.Entry(inquiry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InquiryExists(id))
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
        public async Task<ActionResult<Inquiry>> PostInquiry(Inquiry inquiry)
        {
          if (_context.Inquiries == null)
          {
              return Problem("Entity set 'AppDbContext.Inquiries'  is null.");
          }
            _context.Inquiries.Add(inquiry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInquiry", new { id = inquiry.Id }, inquiry);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInquiry(int id)
        {
            if (_context.Inquiries == null)
            {
                return NotFound();
            }
            var inquiry = await _context.Inquiries.FindAsync(id);
            if (inquiry == null)
            {
                return NotFound();
            }

            _context.Inquiries.Remove(inquiry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InquiryExists(int id)
        {
            return (_context.Inquiries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
