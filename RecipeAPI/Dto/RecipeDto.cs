namespace RecipeAPI.Dto.RecipeDto
{
    public class RecipeDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public DateTime DateAdded { get; init; }
        public List<string> Ingredients { get; set; }
    }
}
