using BeursKracht.Infrastructure.Messaging;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ExchangeService
{
    class Program
    {
        private static string _env;
        public static IConfigurationRoot Config { get; private set; }

        static Program()
        {
            _env = Environment.GetEnvironmentVariable("BEURSKRACHT_ENVIRONMENT");

            Console.WriteLine($"Environment: {_env}");

            Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{_env}.json", optional: false)
                .Build();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Starting application...");
            // get configuration
            var rabbitMQConfigSection = Config.GetSection("RabbitMQ");
            string host = rabbitMQConfigSection["Host"];
            string userName = rabbitMQConfigSection["UserName"];
            string password = rabbitMQConfigSection["Password"];

            RabbitMQMessageHandler messageHandler = new RabbitMQMessageHandler(host, userName, password, "BeursKracht", "", "");


            // start event-handler
            EventHandler eventHandler = new EventHandler(messageHandler);
            eventHandler.Start();

            Console.ReadLine();
        }
    }
}
