using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoDBZ.Data;
using ProjetoDBZ.Models;

namespace ProjetoDBZ.Controllers 
{
    [ApiController]
    [Route ("api/[controller]")]
    public class CharacterController : ControllerBase 
    {
        private readonly AppDbContext _appDbContext;

        public CharacterController(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter(Character character) {
            if (character == null) {
                return BadRequest("tu é burro?");
            }

            _appDbContext.Characters.Add(character);
            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, character);
        }

        [HttpGet("/GetAllCharacters")]
        public async Task<ActionResult<IEnumerable<Character>>> GetAllCharacters() {
             var characters = await _appDbContext.Characters.ToListAsync();
             return Ok(characters);
        }

        [HttpGet("{id}")]
         public async Task<ActionResult<Character>> GetCharacterById(int id) {

            var character = await _appDbContext.Characters.FindAsync(id);
            if (character == null) {
                return NotFound("Character not found!");
            }
            return StatusCode(200, character);
         }

         [HttpPut("/{id}")]
         public async Task<IActionResult> UpdateCharacterById(int id, Character updatedCharacter) {

            var existingCharacter =  await _appDbContext.Characters.FindAsync(id);
            if (existingCharacter == null) {
                return NotFound("Character not found!");
            }

            existingCharacter.Name = updatedCharacter.Name;
            existingCharacter.Type = updatedCharacter.Type;

            /*Another mode for update
            _appDbContext.Entry(existingCharacter).CurrentValues.SetValues(updatedCharacter);
            */
            await _appDbContext.SaveChangesAsync();
            return Ok(updatedCharacter);
         }    

         [HttpDelete("/{id}")]
         public async Task<ActionResult> DeleteCharacterById(int id) {

            if (await _appDbContext.Characters.FindAsync(id) is Character character) {
                    _appDbContext.Characters.Remove(character);
                    await _appDbContext.SaveChangesAsync();
                    return NoContent();
            }
            return NotFound("Character not found!");
         }
    }
}