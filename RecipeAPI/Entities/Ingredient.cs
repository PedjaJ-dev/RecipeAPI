using System.ComponentModel.DataAnnotations;

namespace RecipeAPI.Entities
{
	public class Ingredient
	{
		public int Id { get; set; }

		[Required, MaxLength(100)]
		public string Name { get; set; }

		[Required, MaxLength(50)]
		public string Type { get; set; }
	}
}

