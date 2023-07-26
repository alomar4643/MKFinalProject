using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MortalKombatDB.Data;
using MortalKombatDB.Models;

namespace MortalKombatDB.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
    public class MovesController : ControllerBase
    {
        private readonly MortalKombatDBContext _context;

        public MovesController(MortalKombatDBContext context)
        {
            _context = context;
        }

        // GET: api/Moves
        [HttpGet]
		//Use of Liskov Substitution Principle. Moves controller inherets from move class.
		public async Task<ActionResult<IEnumerable<Move>>> GetMoves()
        {
          if (_context.Moves == null)
          {
              return NotFound();
          }
            return await _context.Moves.ToListAsync();
        }

        // GET: api/Moves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Move>> GetMove(Guid id)
        {
          if (_context.Moves == null)
          {
              return NotFound();
          }
            var move = await _context.Moves.FindAsync(id);

            if (move == null)
            {
                return NotFound();
            }

            return move;
        }

        // PUT: api/Moves/5
        [HttpPut("{id}")]
		//Use of Liskov Substitution Principle. Moves controller inherets from move class.
		public async Task<IActionResult> PutMove(Guid id, Move move)
        {
            if (id != move.Id)
            {
                return BadRequest();
            }

            _context.Entry(move).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoveExists(id))
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

        // POST: api/Moves
        [HttpPost]
        public async Task<ActionResult<Move>> PostMove(Move move)
        {
          if (_context.Moves == null)
          {
              return Problem("Entity set 'MortalKombatDBContext.Moves'  is null.");
          }
            _context.Moves.Add(move);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMove", new { id = move.Id }, move);
        }

        // DELETE: api/Moves/5
        [HttpDelete("{id}")]
		//Use of Liskov Substitution Principle. Moves controller inherets from move class.
		public async Task<IActionResult> DeleteMove(Guid id)
        {
            if (_context.Moves == null)
            {
                return NotFound();
            }

            var move = await _context.Moves.FindAsync(id);
            if (move == null)
            {
                return NotFound();
            }

            _context.Moves.Remove(move);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoveExists(Guid id)
        {
            return (_context.Moves?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
