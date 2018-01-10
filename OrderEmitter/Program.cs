using BeursKracht.Infrastructure.Messaging;
using Microsoft.Extensions.Configuration;
using OrderEmitter.Events;
using System;
using System.IO;
using System.Threading;

namespace OrderEmitter
{
    class Program
    {
        private static string _env;
        public static IConfigurationRoot Config { get; private set; }
        private static IMessagePublisher _messagePublisher;

        static Program()
        {
            _env = Environment.GetEnvironmentVariable("BEURSKRACHT_ENVIRONMENT");

            Console.WriteLine($"Environment: {_env}");

            Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{_env}.json", optional: false)
                .Build();

            var rabbitMQConfigSection = Config.GetSection("RabbitMQ");
            string host = rabbitMQConfigSection["Host"];
            string userName = rabbitMQConfigSection["UserName"];
            string password = rabbitMQConfigSection["Password"];

            _messagePublisher = new RabbitMQMessagePublisher(host, userName, password, "BeursKracht");
        }

        static void Main(string[] args)
        {
            Array orderTypes = Enum.GetValues(typeof(OrderType));
            Random random = new Random();

            for (int i =0; i < 1000; i++)
            {
                
                OrderType randomOrderType = (OrderType)orderTypes.GetValue(random.Next(orderTypes.Length));
                var message = new OrderRegistered(
                    Guid.NewGuid(), 
                    random.Next(1, 10).ToString(), 
                    randomOrderType, 
                    (decimal)random.Next(1, 10), 
                    (decimal)random.Next(1, 10));

                _messagePublisher.PublishMessageAsync(MessageTypes.RegisterOrder, message, "");
                Thread.Sleep(1000);
            }
        }
    }
}
