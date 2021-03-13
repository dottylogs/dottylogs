using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DottyLogs.Server.DbModels
{
    [Index(nameof(TraceIdentifier))]
    public class DottyLogLine
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public DateTime DateTimeUtc { get; set; }

        public string TraceIdentifier { get; set; }

        [NotMapped]
        public string SpanIdentifier { get; set; }

        public long DottySpanId { get; set; }
    }
}
