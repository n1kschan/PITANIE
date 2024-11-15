namespace Питание.Contracts.FoodItem
{
    public class GetFoodItemResponse
    {
        public int Fooditemid { get; set; }
        public string Foodname { get; set; } = null!;
        public int Calories { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fats { get; set; }
    }
}
