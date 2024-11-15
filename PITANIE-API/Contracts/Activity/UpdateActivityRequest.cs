namespace Питание.Contracts.Activity
{
    public class UpdateActivityRequest
    {
        public int Userid { get; set; }
        public string Activityname { get; set; } = null!;
        public int Caloriesburned { get; set; }
        public int Duration { get; set; }
    }
}
