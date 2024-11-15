namespace Питание.Contracts.Meal
{
    public class CreateMealRequest
    {
        public int Mealplanid { get; set; }
        public string Mealtype { get; set; } = null!;
        public DateTime Mealdate { get; set; }
    }
}
