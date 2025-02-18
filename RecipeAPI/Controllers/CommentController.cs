using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeAPI.Data;
using RecipeAPI.Entities;
using System.Security.Claims;

namespace RecipeAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{recipeId}")]
        public async Task<IActionResult> GetComments(int recipeId)
        {
            var comments = await _context.Comments.Where(c => c.RecipeId == recipeId).ToListAsync();
            return Ok(comments);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("{recipeId}")]
        public async Task<IActionResult> AddComment(int recipeId, [FromBody] string content)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var comment = new Comment
            {
                Content = content,
                RecipeId = recipeId,
                UserId = userId
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Komentar dodat!" });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] string content)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
                return NotFound("Komentar nije pronađen.");

            comment.Content = content;
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Komentar uspešno izmenjen!" });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
                return NotFound("Komentar nije pronađen.");

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Komentar uspešno obrisan!" });
        }
    }
}
