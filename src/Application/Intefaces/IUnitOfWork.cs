using System;
using Domain.Entities;

namespace Application.Intefaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITodoItemRepository TodoItem { get; }

        int Commit();
    }
}

