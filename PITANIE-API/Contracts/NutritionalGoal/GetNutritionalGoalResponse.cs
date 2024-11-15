namespace Питание.Contracts.NutritionalGoal
{
    public class GetNutritionalGoalResponse
    {
        public int Goalid { get; set; }
        public int Userid { get; set; }
        public int Dailycaloricintake { get; set; }
        public double Proteingoal { get; set; }
        public double Carbohydrategoal { get; set; }
        public double Fatgoal { get; set; }
    }
}
