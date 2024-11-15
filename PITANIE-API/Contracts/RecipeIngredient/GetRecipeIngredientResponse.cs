namespace Питание.Contracts.RecipeIngredient
{
    public class GetRecipeIngredientResponse
    {
        public int Recipeingredientid { get; set; }
        public int Recipeid { get; set; }
        public int Fooditemid { get; set; }
        public double Quantity { get; set; }
    }
}
