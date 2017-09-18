using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace SignalRClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press AnyKey To Start");
            HubClientInit();
            Console.ReadKey();
        }

        private static void HubClientInit()
        {
            //throw new NotImplementedException();
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:61547/messagehub")
                .WithConsoleLogger()
                .Build();

            connection.On<string>("Send", data =>
            {
                Console.WriteLine($"Received: {data}");
            });

            connection.StartAsync();

            string str = "Hello";
            connection.InvokeAsync("Send",str);
            //connection.InvokeAsync("Ping");
        }
    }
}
