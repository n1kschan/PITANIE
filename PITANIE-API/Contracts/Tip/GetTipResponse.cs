﻿namespace Питание.Contracts.Tip
{
    public class GetTipResponse
    {
        public int TipID { get; set; }
        public int UserID { get; set; }
        public string TipText { get; set; } = null!;
        public string Category { get; set; } = null!;
    }
}