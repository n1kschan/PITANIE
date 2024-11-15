namespace Питание.Contracts.Profile
{
    public class UpdateProfileRequest
    {
        public int Userid { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public DateTime Dateofbirth { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Gender { get; set; } = null!;
    }
}
