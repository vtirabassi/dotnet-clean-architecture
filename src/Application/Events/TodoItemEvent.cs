using System;
using Domain.Events;
using MediatR;

namespace Application.Events
{
    public class TodoItemEvent :
        INotificationHandler<DomainEventNotification<CreatedTodoItemEvent>>,
        INotificationHandler<DomainEventNotification<ErrorEvent>>
    {
        public TodoItemEvent()
        {
        }

        public Task Handle(DomainEventNotification<CreatedTodoItemEvent> notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DomainEventNotification<ErrorEvent> notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

