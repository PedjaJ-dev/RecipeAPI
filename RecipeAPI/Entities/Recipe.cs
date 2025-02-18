using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeAPI.Entities
{
	public class Recipe
	{
		public int Id { get; set; }

		[Required, MaxLength(100)]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public DateTime DateAdded { get; set; } 

		[ForeignKey(nameof(User))]
		public int UserId { get; set; }
		public User User { get; set; }

		public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
		public ICollection<Comment> Contents { get; set; }
	}
}
