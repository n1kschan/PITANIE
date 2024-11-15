namespace Питание.Contracts.Meal
{
    public class UpdateMealRequest
    {
        public int Mealplanid { get; set; }
        public string Mealtype { get; set; } = null!;
        public DateTime Mealdate { get; set; }
    }
}
