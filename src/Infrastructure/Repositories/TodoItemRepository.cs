using System;
using Application.Intefaces;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class TodoItemRepository : Repository<TodoItem>, ITodoItemRepository
    {
        public TodoItemRepository(AppDbContext context) : base(context)
        {
        }
    }
}

