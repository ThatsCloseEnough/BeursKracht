﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeursKracht.Infrastructure.Messaging
{
    public interface IMessageHandlerCallback
    {
        Task<bool> HandleMessageAsync(MessageTypes messageType, string message);
    }
}
