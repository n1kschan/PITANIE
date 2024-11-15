namespace Питание.Contracts.RecipeIngredient
{
    public class DeleteRecipeIngredientRequest
    {
        public int Recipeingredientid { get; set; }
        public int Recipeid { get; set; }
        public int Fooditemid { get; set; }
        public double Quantity { get; set; }
    }
}
