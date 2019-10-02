using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Messaging
{
    /// <summary>
    /// Represents that the implemented classes are the command senders
    /// that will send a command to the message bus.
    /// </summary>
    public interface ICommandSender : IMessagePublisher
    {
    }
}
