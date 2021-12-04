using System;
using Domain.Entities;

namespace Application.Intefaces
{
    public interface ITodoItemRepository : IRepository<TodoItem>
    {
    }
}

