using System;
using System.Collections.Generic;
using System.Text;

namespace BeursKracht.Infrastructure.Messaging
{
    public class Event : Message
    {
        public Event(Guid messageId, MessageTypes messageType) : base(messageId, messageType)
        {
        }
    }
}
