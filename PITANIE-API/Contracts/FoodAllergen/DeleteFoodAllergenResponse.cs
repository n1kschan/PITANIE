namespace Питание.Contracts.FoodAllergen
{
    public class DeleteFoodAllergenRequest
    {
        public int FoodAllergenid { get; set; }
        public int Fooditemid { get; set; }
        public int Allergenid { get; set; }
    }
}
