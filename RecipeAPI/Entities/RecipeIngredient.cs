using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeAPI.Entities
{
	public class RecipeIngredient
	{
		public int Id { get; set; }
		[ForeignKey(nameof(Recipe))]
		public int RecipeId { get; set; }
		public Recipe Recipe { get; set; }

		[ForeignKey(nameof(Ingredient))]
		public int IngredientId { get; set; }
		public Ingredient Ingredient { get; set; }

		public decimal Quantity { get; set; }

        [Required]
        public string Unit { get; set; }
    }
}
