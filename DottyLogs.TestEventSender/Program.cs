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
            var client = new GrpcDottyLogs.DottyLogs.DottyLogsClient(channel);
            while (notquit)
            {
                Console.WriteLine("Press any key to send");
                var reply = await client.StartSpanAsync(
                              new GrpcDottyLogs.StartSpanRequest { RequestUrl = "/test-" + new Random().Next(0, 1000), ThreadId = new Random().Next(0, 1000), TraceIdentifier = "121412312" + new Random().Next(0, 1000) });
                Console.WriteLine("Sent");
                
                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    notquit = false;
                }
            }
        }
    }
}
