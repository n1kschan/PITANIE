namespace Питание.Contracts.UserPreference
{
    public class UpdateUserPreferenceRequest
    {
        public int UserID { get; set; }
        public string PreferenceName { get; set; } = null!;
        public string PreferenceValue { get; set; } = null!;
    }
}
