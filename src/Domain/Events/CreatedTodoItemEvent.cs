using Domain.Commons;
using Domain.Entities;

namespace Domain.Events;

public class CreatedTodoItemEvent : DomainEvent
{
    public CreatedTodoItemEvent(TodoItem todoItem, bool IsPublished = false)
    {
        TodoItem = todoItem;
        this.IsPublished = IsPublished;
    }

    public TodoItem TodoItem { get; }
}
