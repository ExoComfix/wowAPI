using Microsoft.AspNetCore.Mvc;
using wowAPI.Data;
using wowAPI.Entities;
using Newtonsoft.Json;

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
            var characterData = _db.MajorCharacters.ToList();
            return JsonConvert.SerializeObject(characterData);
        }

        [HttpGet("/api/character/{characterId}")]
        public async Task<string> GetCharacterById(int characterId)
        {
        var character = await _db.MajorCharacters.FindAsync(characterId);
        if (character == null)
        {
            return "Character Not Found !";
        }
            return JsonConvert.SerializeObject(character);
        }

        [HttpPost("/api/character/{characterId}")]
        public async Task<string> UpdateCharacterById(int characterId, [FromBody] MajorCharacter newModel)
        {
            _db.Add(newModel);
            await _db.SaveChangesAsync();
            return "true";
        }
        
        [HttpPost("/api/expansion")]
        public async Task<string> AddExpansion(int expansionId, [FromBody] Expansion newModel)
        {
            _db.Expansions.Add(newModel);
            await _db.SaveChangesAsync();
            return "true";
        }

        [HttpDelete("/api/character/{characterId}")]
        public async Task<string> DeleteCharacterById(int characterId)
        {
        var character = await _db.MajorCharacters.FindAsync(characterId);
        if (character == null)
        {
            return "Character Not Found !";
        }
            _db.MajorCharacters.Remove(character);
            _db.SaveChanges();
            return "Character Deleted";
        }
    }
}