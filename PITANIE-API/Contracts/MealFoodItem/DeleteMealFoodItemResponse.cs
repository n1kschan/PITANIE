namespace Питание.Contracts.MealFoodItem
{
    public class DeleteMealFoodItemRequest
    {
        public int Mealfooditemid { get; set; }
        public int Mealid { get; set; }
        public int Fooditemid { get; set; }
        public double Servingsize { get; set; }
    }
}
