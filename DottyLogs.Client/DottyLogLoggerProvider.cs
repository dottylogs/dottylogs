using DottyLogs.Client.BackgroundServices;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace DottyLogs
{
    public sealed class DottyLogLoggerProvider : ILoggerProvider
    {
        private readonly DottyLogLoggerConfiguration _config;
        private readonly DottyLogSink _sink;
        private readonly ConcurrentDictionary<string, DottyLogLogger> _loggers = new();

        public DottyLogLoggerProvider(DottyLogLoggerConfiguration config, DottyLogSink sink)
        {
            _config = config;
            _sink = sink;
        }
           

        public ILogger CreateLogger(string categoryName) =>
            _loggers.GetOrAdd(categoryName, name => new DottyLogLogger(name, _config, _sink));

        public void Dispose() => _loggers.Clear();
    }
}
