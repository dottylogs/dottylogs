using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace DottyLogs.TestEventSender
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var notquit = true;
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new GrpcDottyLogsClient.DottyLogs.DottyLogsClient(channel);
            while (notquit)
            {
                Console.WriteLine("Press any key to send");
                var reply = await client.StartSpanAsync(
                              new GrpcDottyLogsClient.StartSpanRequest { RequestUrl = "/test-" + new Random().Next(0, 1000), RequestUpdateStatus = "Started", ThreadId = "12231" + new Random().Next(0, 1000), TracingIdentifier = "121412312" + new Random().Next(0, 1000) });
                Console.WriteLine("Sent: " + reply.Message);
                
                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    notquit = false;
                }
            }
        }
    }
}
