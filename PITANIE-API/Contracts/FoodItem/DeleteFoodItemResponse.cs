namespace Питание.Contracts.FoodItem
{
    public class DeleteFoodItemRequest
    {
        public int Fooditemid { get; set; }
        public string Foodname { get; set; } = null!;
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fats { get; set; }
    }
}
