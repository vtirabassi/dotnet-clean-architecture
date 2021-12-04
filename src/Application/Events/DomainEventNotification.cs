using System;
using Domain.Commons;
using MediatR;

namespace Domain.Events
{
    public class DomainEventNotification<TEvent> : INotification where TEvent : DomainEvent
    {
        public DomainEventNotification(TEvent @event)
        {
            Event = @event;
        }

        public TEvent Event { get; set; }
    }
}

