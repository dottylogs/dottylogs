using DottyLogs.Client.BackgroundServices;
using Microsoft.Extensions.Logging;
using System;

namespace DottyLogs
{
    public class DottyLogLogger : ILogger
    {
        private readonly string _name;
        private readonly DottyLogLoggerConfiguration _config;
        private readonly DottyLogSink _sink;

        public DottyLogLogger(
            string name,
            DottyLogLoggerConfiguration config,
            DottyLogSink sink) =>
            (_name, _config, _sink) = (name, config, sink);

        public IDisposable BeginScope<TState>(TState state) => default;

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            _sink.EnqueueLog($"{_name} - {formatter(state, exception)}");
        }
    }
}
