using Microsoft.EntityFrameworkCore;
using System;

namespace DottyLogs.Server.DbModels
{
    [Index(nameof(TraceIdentifier))]
    public class DottyTrace
    {
        public long Id { get; set; }

        public string TraceIdentifier { get; set; }
        public DateTime StartedAtUtc { get; set; }
        public DateTime? StoppedAtUtc { get; set; }
        public string RequestUrl { get; set; }

        public DottySpan SpanData { get; set; }
    }
}
