using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.DomainEvents
{
    public abstract class DomainEventHandler<TDomainEvent> :
        IDomainEventHandler<TDomainEvent>
        where TDomainEvent : IDomainEvent
    {
        public abstract Task ExecuteAsync(TDomainEvent args);
    }
}
