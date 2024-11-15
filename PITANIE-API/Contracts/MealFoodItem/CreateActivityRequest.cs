namespace Питание.Contracts.MealFoodItem
{
    public class CreateMealFoodItemRequest
    {
        public int Mealid { get; set; }
        public int Fooditemid { get; set; }
        public decimal Servingsize { get; set; }
    }
}
