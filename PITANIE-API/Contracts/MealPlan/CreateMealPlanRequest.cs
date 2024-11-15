namespace Питание.Contracts.MealPlan
{
    public class CreateMealPlanRequest
    {
        public int Userid { get; set; }
        public string Planname { get; set; } = null!;
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
    }
}
