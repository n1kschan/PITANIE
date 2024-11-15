namespace Питание.Contracts.Meal
{
    public class GetMealResponse
    {
        public int Mealid { get; set; }
        public int Mealplanid { get; set; }
        public string Mealtype { get; set; } = null!;
        public DateTime Mealdate { get; set; }
    }
}
