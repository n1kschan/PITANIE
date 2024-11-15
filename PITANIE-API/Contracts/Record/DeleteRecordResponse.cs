namespace Питание.Contracts.Record
{
    public class DeleteRecordRequest
    {
        public int Recordid { get; set; }
        public int Userid { get; set; }
        public int Activityid { get; set; }
        public DateTime Recorddate { get; set; }
    }
}
