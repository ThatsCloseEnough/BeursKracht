using System;
using BeursKracht.Infrastructure.Messaging;

namespace ExchangeService.Events
{
    public class SaleWasMade : Event
    {
        public decimal Price { get; }
        public decimal Amount { get; }
        public string SellerId { get; }
        public string BuyerId { get; }

        public SaleWasMade(Guid messageId, decimal price, decimal amount, string sellerId, string buyerId) : base(messageId, MessageTypes.SaleWasMade)
        {
            Price = price;
            Amount = price;
            SellerId = sellerId;
            BuyerId = buyerId;
        }
    }
}
