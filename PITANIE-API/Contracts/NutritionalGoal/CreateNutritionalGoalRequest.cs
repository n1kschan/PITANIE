namespace Питание.Contracts.NutritionalGoal
{
    public class CreateNutritionalGoalRequest
    {
        public int Userid { get; set; }
        public int Dailycaloricintake { get; set; }
        public decimal Proteingoal { get; set; }
        public decimal Carbohydrategoal { get; set; }
        public decimal Fatgoal { get; set; }
    }
}
