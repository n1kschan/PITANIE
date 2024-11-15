namespace Питание.Contracts.RecipeIngredient
{
    public class CreateRecipeIngredientRequest
    {
        public int Recipeid { get; set; }
        public int Fooditemid { get; set; }
        public decimal Quantity { get; set; }
    }
}
