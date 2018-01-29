using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.DomainEvents
{
    public interface IDomainEventHandler<TDomainEvent> where TDomainEvent : IDomainEvent
    {
        Task ExecuteAsync(TDomainEvent args);
    }
}
