namespace Питание.Contracts.Tip
{
    public class CreateTipRequest
    {
        public int UserID { get; set; }
        public string TipText { get; set; } = null!;
        public string Category { get; set; } = null!;
    }
}
