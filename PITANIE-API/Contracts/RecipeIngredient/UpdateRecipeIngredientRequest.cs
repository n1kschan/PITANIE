namespace Питание.Contracts.RecipeIngredient
{
    public class UpdateRecipeIngredientRequest
    {
        public int Recipeid { get; set; }
        public int Fooditemid { get; set; }
        public double Quantity { get; set; }
    }
}
