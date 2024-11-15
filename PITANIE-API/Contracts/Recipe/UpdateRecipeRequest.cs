namespace Питание.Contracts.Recipe
{
    public class UpdateRecipeRequest
    {
        public string Recipename { get; set; } = null!;
        public int Preparationtime { get; set; }
        public int Cookingtime { get; set; }
        public string Instructions { get; set; } = null!;
    }
}
