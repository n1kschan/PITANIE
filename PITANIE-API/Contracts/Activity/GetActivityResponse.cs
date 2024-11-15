namespace Питание.Contracts.Activity
{
    public class GetActivityResponse
    {
        public int Activityid { get; set; }
        public int Userid { get; set; }
        public string Activityname { get; set; } = null!;
        public int Caloriesburned { get; set; }
        public int Duration { get; set; }
    }
}
