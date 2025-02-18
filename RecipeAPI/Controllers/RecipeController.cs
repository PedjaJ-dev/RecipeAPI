using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeAPI.Data;
using RecipeAPI.Dto.RecipeDto;
using RecipeAPI.Entities;
using System.Security.Claims;

namespace RecipeAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/recipes")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RecipeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 🔹 Prikaz svih recepata sa paginacijom
        [HttpGet]
        public async Task<IActionResult> GetRecipes([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var recipes = await _context.Recipes
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(r => new RecipeDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    DateAdded = r.DateAdded,
                    Ingredients = r.RecipeIngredients.Select(ri => ri.Ingredient.Name).ToList()
                })
                .ToListAsync();

            return Ok(recipes);
        }

        // 🔹 Dodavanje novog recepta
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddRecipe([FromBody] RecipeForCreationDto recipeDto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var recipe = new Recipe
            {
                Name = recipeDto.Name,
                Description = recipeDto.Description,
                UserId = userId,
                RecipeIngredients = recipeDto.IngredientIds.Select(id => new RecipeIngredient
                {
                    IngredientId = id
                }).ToList()
            };

            _context.Recipes.Add(recipe);

            foreach (var ingredient in recipe.RecipeIngredients)
            {
                if (string.IsNullOrEmpty(ingredient.Unit))
                {
                    ingredient.Unit = "pcs"; // ili neka druga podrazumevana vrednost
                }
            }


            await _context.SaveChangesAsync();

            return Ok(new { Message = "Recept uspešno dodat!" });
        }

        // 🔹 Izmena recepta (PUT)
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipe(int id, [FromBody] RecipeForCreationDto recipeDto)
        {
            var recipe = await _context.Recipes.Include(r => r.RecipeIngredients).FirstOrDefaultAsync(r => r.Id == id);
            if (recipe == null)
                return NotFound("Recept nije pronađen.");

            recipe.Name = recipeDto.Name;
            recipe.Description = recipeDto.Description;
            recipe.RecipeIngredients.Clear();
            recipe.RecipeIngredients = recipeDto.IngredientIds.Select(id => new RecipeIngredient
            {
                IngredientId = id,
                Unit = "pcs" // ili druga podrazumevana vrednost
            }).ToList();


            await _context.SaveChangesAsync();
            return Ok(new { Message = "Recept uspešno izmenjen!" });
        }

        // 🔹 Brisanje recepta (DELETE)
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
                return NotFound("Recept nije pronađen.");

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Recept uspešno obrisan!" });
        }
    }
}


