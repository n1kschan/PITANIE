namespace Питание.Contracts.Record
{
    public class UpdateRecordRequest
    {
        public int Userid { get; set; }
        public int Activityid { get; set; }
        public DateTime Recorddate { get; set; }
    }
}
