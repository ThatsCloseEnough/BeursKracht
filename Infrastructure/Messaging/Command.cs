﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BeursKracht.Infrastructure.Messaging
{
    public class Command : Message
    {
        public Command(Guid messageId, MessageTypes messageType) : base(messageId, messageType)
        {
        }
    }
}
