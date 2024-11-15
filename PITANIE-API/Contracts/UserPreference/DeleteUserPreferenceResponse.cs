namespace Питание.Contracts.UserPreference
{
    public class DeleteUserPreferenceRequest
    {
        public int UserPreferenceID { get; set; }
        public int UserID { get; set; }
        public string PreferenceName { get; set; } = null!;
        public string PreferenceValue { get; set; } = null!;
    }
}
