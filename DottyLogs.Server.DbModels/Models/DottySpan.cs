using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DottyLogs.Server.DbModels
{
    [Index(nameof(SpanIdentifier))]
    [Index(nameof(TraceIdentifier))]
    public class DottySpan
    {
        public long Id { get; set; }
        public string RequestUrl { get; set; }
        public string SpanIdentifier { get; set; }
        public string TraceIdentifier { get; set; }
        public string HostName { get; set; }
        public string ApplicationName { get; set; }
        public DateTime StartedAtUtc { get; set; }
        public DateTime? StoppedAtUtc { get; set; }
        public List<DottyLogLine> Logs { get; set; } = new();
        public List<DottySpan> ChildSpans { get; set; } = new();

        public long? DottySpanId { get; set; }
    }
}
