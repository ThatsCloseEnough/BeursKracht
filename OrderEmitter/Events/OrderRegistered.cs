using BeursKracht.Infrastructure.Messaging;
using System;

namespace OrderEmitter.Events
{
    public class OrderRegistered : Event
    {
        public string RequestorId { get; }
        public OrderType OrderType { get; }
        public decimal Price { get; }
        public decimal Amount { get; }

        public OrderRegistered(Guid messageId, string requestorId, OrderType orderType, decimal price, decimal amount)
            : base(messageId, MessageTypes.SaleWasMade)
        {
            RequestorId = requestorId;
            OrderType = orderType;
            Price = price;
            Amount = amount;
        }
    }

    public enum OrderType
    {
        Buy,
        Sell
    }
}
