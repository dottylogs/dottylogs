namespace DottyLogs.Models
{
    public class TracingUpdate
    {
        public RequestUpdateState RequestUpdateStatus { get; set; }
        public string TracingIdentifier { get; set; }
        public int ThreadId { get; set; }
        public string RequestUrl { get; set; }
    }
}
