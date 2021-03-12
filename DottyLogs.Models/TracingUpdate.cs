namespace DottyLogs.Models
{
    public class TracingUpdate
    {
        public RequestUpdateState RequestUpdateStatus { get; set; }
        public string traceIdentifier { get; set; }
        public int ThreadId { get; set; }
        public string RequestUrl { get; set; }
    }
}
