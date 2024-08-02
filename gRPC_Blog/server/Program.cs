using Grpc.Core;
using System;
using System.IO;

namespace server
{
    class Program
    {
        const int Port = 50052;
        static void Main(string[] args)
        {
            Server? server = null;

            try
            {
                server = new Server()
                {
                    Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
                };
                server.Start();
                Console.WriteLine("the server is listening on port: " + Port);
                Console.ReadKey();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            finally
            {
                if (server != null)
                    server.ShutdownAsync().Wait();
            }
        }
    }
}