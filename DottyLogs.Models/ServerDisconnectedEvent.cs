namespace DottyLogs.Models
{
    public class ServerDisconnectedEvent
    {
        public string TraceIdentifier { get; set; }
    }
    
    public class ServerConnectedEvent
    {
        public string TraceIdentifier { get; set; }
        public string HostName { get; set; }
        public string ApplicationName { get; set; }
    }
}
