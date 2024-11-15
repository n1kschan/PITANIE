namespace Питание.Contracts.MealFoodItem
{
    public class UpdateMealFoodItemRequest
    {
        public int Mealid { get; set; }
        public int Fooditemid { get; set; }
        public double Servingsize { get; set; }
    }
}
