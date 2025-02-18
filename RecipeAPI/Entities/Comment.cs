using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Design;

namespace RecipeAPI.Entities
{
	public class Comment
	{
		public int Id { get; set; }

		[Required]
		public string Content { get; set; }

		[ForeignKey(nameof(Recipe))]
		public int RecipeId { get; set; }
		public Recipe Recipe { get; set; }

        public int UserId { get; set; }
    }
}

