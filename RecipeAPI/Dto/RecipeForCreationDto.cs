namespace RecipeAPI.Dto.RecipeDto
{
    public class RecipeForCreationDto
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public List<int> IngredientIds { get; set; }
    }
}
