using System;
using Grpc.Core;
using System.IO;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Channel channel = new Channel("localhost", 50052, ChannelCredentials.Insecure);

            await channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    Console.WriteLine("the client connected successfully");
                }
            });
            channel.ShutdownAsync().Wait();
            Console.ReadKey();
        }
    }
}