using Microsoft.AspNetCore.Mvc;
using ProjetoDBZ.Data;

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
    }
}