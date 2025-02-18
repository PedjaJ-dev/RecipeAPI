using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeAPI.Data;
using RecipeAPI.Entities;

namespace RecipeAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/ingredients")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IngredientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 🔹 Prikaz svih sastojaka
        [HttpGet]
        public async Task<IActionResult> GetIngredients()
        {
            var ingredients = await _context.Ingredients.ToListAsync();
            return Ok(ingredients);
        }

        // 🔹 Dodavanje novog sastojka (samo admin može dodati)
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddIngredient([FromBody] Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Sastojak uspešno dodat!" });
        }

        // 🔹 Izmena sastojka
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIngredient(int id, [FromBody] Ingredient updatedIngredient)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
                return NotFound("Sastojak nije pronađen.");

            ingredient.Name = updatedIngredient.Name;
            ingredient.Type = updatedIngredient.Type;

            await _context.SaveChangesAsync();
            return Ok(new { Message = "Sastojak uspešno izmenjen!" });
        }

        // 🔹 Brisanje sastojka
        [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
                return NotFound("Sastojak nije pronađen.");

            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Sastojak uspešno obrisan!" });
        }
    }
}
