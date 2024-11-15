namespace Питание.Contracts.Record
{
    public class CreateRecordRequest
    {
        public int Userid { get; set; }
        public int Activityid { get; set; }
        public DateTime Recorddate { get; set; }
    }
}
