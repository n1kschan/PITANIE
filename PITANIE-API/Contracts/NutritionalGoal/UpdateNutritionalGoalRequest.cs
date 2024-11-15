namespace Питание.Contracts.NutritionalGoal
{
    public class UpdateNutritionalGoalRequest
    {
        public int Userid { get; set; }
        public int Dailycaloricintake { get; set; }
        public double Proteingoal { get; set; }
        public double Carbohydrategoal { get; set; }
        public double Fatgoal { get; set; }
    }
}
