using Microsoft.AspNetCore.Mvc;
using wowAPI.Data;
using wowAPI.Entities;

namespace wowAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly DataContext _db;
        public ApiController(
            DataContext db
        )
        {
            _db =  db;
        }

        [HttpGet("/api/character")]
        public async Task<string> GetCharacters()
        {
            return "";
        }

        [HttpGet("/api/character/{characterId}")]
        public async Task<string> GetCharacterById(int characterId)
        {
            return "";
        }

        [HttpPost("/api/character/{characterId}")]
        public async Task<string> UpdateCharacterById(int characterId, [FromBody] MajorCharacter newModel)
        {
            return "";
        }

        [HttpDelete("/api/character/{characterId}")]
        public async Task<string> DeleteCharacterById(int characterId)
        {
            return "";
        }
    }
}