using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MortalKombatDB.Data;
using MortalKombatDB.Models;

namespace MortalKombatDB.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly MortalKombatDBContext _context;

        public CharactersController(MortalKombatDBContext context)
        {
            _context = context;
        }

        // GET: api/Characters
        [HttpGet]
		//Use of Liskov Substitution Principle. Character controller inherets from character class.
		public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
          if (_context.Characters == null)
          {
              return NotFound();
          }
            return await _context.Characters.ToListAsync();
        }

        // GET: api/Characters/5
        [HttpGet("{id}")]
		public async Task<ActionResult<Character>> GetCharacter(Guid id)
        {
          if (_context.Characters == null)
          {
              return NotFound();
          }
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            return character;
        }

        // PUT: api/Characters/5
 
        [HttpPut("{id}")]
		//Use of Liskov Substitution Principle. Character controller inherets from character class.
		public async Task<IActionResult> PutCharacter(Guid id, Character character)
        {
            if (id != character.Id)
            {
                return BadRequest();
            }

            _context.Entry(character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
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

        // POST: api/Characters

        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
          if (_context.Characters == null)
          {
              return Problem("Entity set 'MortalKombatDBContext.Characters'  is null.");
          }
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacter", new { id = character.Id }, character);
        }

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
		//Use of Liskov Substitution Principle. Character controller inherets from character class.
		public async Task<IActionResult> DeleteCharacter(Guid id)
        {
            if (_context.Characters == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterExists(Guid id)
        {
            return (_context.Characters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
