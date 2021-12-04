using System;
namespace Domain.Commons
{
    public abstract class DomainEvent
    {
        protected DomainEvent()
        {
            DateOccurred = DateTimeOffset.UtcNow;
        }

        public bool IsPublished { get; set; }
        public DateTimeOffset DateOccurred { get; private set; } = DateTime.UtcNow;
    }
}

