using Microsoft.AspNetCore.Mvc;
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
    }
}