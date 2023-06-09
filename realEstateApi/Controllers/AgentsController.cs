using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using realEstateApi.Context;
using realEstateApi.Models;

namespace realEstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AgentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agent>>> GetAgents()
        {
          if (_context.Agents == null)
          {
              return NotFound();
          }
            return await _context.Agents.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Agent>> GetAgent(int id)
        {
          if (_context.Agents == null)
          {
              return NotFound();
          }
            var agent = await _context.Agents.FindAsync(id);

            if (agent == null)
            {
                return NotFound();
            }

            return agent;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgent(int id, Agent agent)
        {
            if (id != agent.Id)
            {
                return BadRequest();
            }

            _context.Entry(agent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgentExists(id))
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
        public async Task<ActionResult<Agent>> PostAgent(Agent agent)
        {
          if (_context.Agents == null)
          {
              return Problem("");
          }
            _context.Agents.Add(agent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgent", new { id = agent.Id }, agent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgent(int id)
        {
            if (_context.Agents == null)
            {
                return NotFound();
            }
            var agent = await _context.Agents.FindAsync(id);
            if (agent == null)
            {
                return NotFound();
            }

            _context.Agents.Remove(agent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgentExists(int id)
        {
            return (_context.Agents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
