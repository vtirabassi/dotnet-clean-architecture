using System;

namespace Application.Commands;

public struct GetByIdTodoItemCommand
{
    public GetByIdTodoItemCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; init; }
}


