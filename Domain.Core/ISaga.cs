using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Events;

namespace Domain.Core
{
    public interface ISaga<TKey, TMessage> //: IAggregateRoot<TKey>
        where TKey : IEquatable<TKey>
        where TMessage : IDomainEvent
    {
        void Transit(TMessage message);
    }
}
