using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using System;

namespace DottyLogs.Client.BackgroundServices
{
    public class DottyLogSink
    {
        private readonly GrpcChannel _channel;
        private readonly GrpcDottyLogs.DottyLogs.DottyLogsClient _client;

        public DottyLogSink(DottyLogLoggerConfiguration config)
        {
            _channel = GrpcChannel.ForAddress(config.DottyAddress);
            _client = new GrpcDottyLogs.DottyLogs.DottyLogsClient(_channel);
        }

        internal void EnqueueLog(string v)
        {
            if (DottyLogsScopedContextAccessor.IsInSpan)
            {
                _client.PushLogMessage(new GrpcDottyLogs.LogRequest { Message = v, Timestamp = DateTime.UtcNow.ToTimestamp(), SpanIdentifier = DottyLogsScopedContextAccessor.DottyLogsScopedContext.SpanId });
            }
            
        }
    }
}
