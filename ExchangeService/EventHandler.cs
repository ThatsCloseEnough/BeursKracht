using System.Threading.Tasks;
using BeursKracht.Infrastructure.Messaging;
using Newtonsoft.Json.Linq;
using ExchangeService.Events;
using System;

namespace ExchangeService
{
    public class EventHandler : IMessageHandlerCallback
    {
        private IMessageHandler _messageHandler;

        public EventHandler(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }

        public void Start()
        {
            _messageHandler.Start(this);
        }

        public void Stop()
        {
            _messageHandler.Stop();
        }

        public async Task<bool> HandleMessageAsync(MessageTypes messageType, string message)
        {
            JObject messageObject = MessageSerializer.Deserialize(message);

            switch (messageType)
            {
                case MessageTypes.RegisterOrder:
                    await HandleAsync(messageObject.ToObject<OrderRegistered>());
                    break;
            }

            return true;
        }

        private async Task<bool> HandleAsync(OrderRegistered e)
        {
            Console.WriteLine("Order was registered");

            return true;
        }
    }
}
