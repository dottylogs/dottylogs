using DottyLogs.Server.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DottyLogs.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraceController : ControllerBase
    {
        private readonly ILogger<TraceController> _logger;
        private readonly DottyDbContext _dbContext;

        public TraceController(ILogger<TraceController> logger, DottyDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("last-ten")]
        public async Task<ActionResult<IEnumerable<DottyTrace>>> GetLastTraces()
        {
            var traces = await _dbContext
                .Traces
                .Where(t => t.StoppedAtUtc != null)
                .OrderByDescending(t => t.StartedAtUtc)
                .Take(10)
                .ToListAsync();

            var traceIdentifiers = traces.Select(t => t.TraceIdentifier);

            var spans = await _dbContext.Spans.Where(t => traceIdentifiers.Contains(t.TraceIdentifier)).ToListAsync();
            var logs = await _dbContext.Logs.Where(l => traceIdentifiers.Contains(l.TraceIdentifier)).ToListAsync();

            var spansGrouping = spans.GroupBy(s => s.TraceIdentifier).ToDictionary(t => t.Key, t => t.ToList());
            var logsGrouping = logs.GroupBy(l => l.TraceIdentifier).ToDictionary(t => t.Key, t => t.ToList());

            foreach (var trace in traces)
            {
                AddChildrenToTrace(trace, spansGrouping.GetValueOrDefault(trace.TraceIdentifier), logsGrouping.GetValueOrDefault(trace.TraceIdentifier));
            }

            return Ok(traces);
        }

        private void AddChildrenToTrace(DottyTrace trace, List<DottySpan> dottySpans, List<DottyLogLine> dottyLogLines)
        {
            var logsLookup = dottyLogLines?.GroupBy(l => l.DottySpanId).ToDictionary(l => l.Key, l => l.ToList());
            var lookup = new Dictionary<long, DottySpan>();
            // head is with no parent
            var parent = dottySpans.Single(s => !s.DottySpanId.HasValue);
            lookup[parent.Id] = parent;
            foreach (var span in dottySpans.Where(s => s.DottySpanId.HasValue).OrderBy(x => x.DottySpanId))
            {
                lookup[parent.Id].ChildSpans.Add(span);
                lookup[span.Id] = span;

                span.Logs = logsLookup?.GetValueOrDefault(span.Id);
            }

        }
    }
}
