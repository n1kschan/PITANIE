namespace Питание.Contracts.Profile
{
    public class CreateProfileRequest
    {
        public int Userid { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public DateTime Dateofbirth { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string Gender { get; set; } = null!;
    }
}
