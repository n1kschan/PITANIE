namespace Питание.Contracts.Recipe
{
    public class CreateRecipeRequest
    {
        public string Recipename { get; set; } = null!;
        public int Preparationtime { get; set; }
        public int Cookingtime { get; set; }
        public string Instructions { get; set; } = null!;
    }
}
