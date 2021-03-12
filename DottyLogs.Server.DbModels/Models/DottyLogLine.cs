using System;

namespace DottyLogs.Server.DbModels
{
    public class DottyLogLine
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public DateTime DateTimeUtc { get; set; }
    }
}
