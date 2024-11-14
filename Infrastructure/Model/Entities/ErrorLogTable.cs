namespace Infra.Model.Entities
{
    public class ErrorLogTable : BaseEntity<long>
    {
        public int UserId { get; set; }
        public string RequestPath { get; set; }
        public string RequestBody { get; set; }
        public byte ApplicationId { get; set; }
        public string ResponseBody { get; set; }
        public string LogMessage { get; set; }
        public int? ErrorCode { get; set; }
        public string IpAddress { get; set; }
        public long ProcessTime { get; set; }
        public DateTime LastTransactionDate { get; set; }
    }

}
