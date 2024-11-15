namespace Питание.Contracts.MealPlan
{
    public class GetMealPlanResponse
    {
        public int Mealplanid { get; set; }
        public int Userid { get; set; }
        public string Planname { get; set; } = null!;
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
    }
}
