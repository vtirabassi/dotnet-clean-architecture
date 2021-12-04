using Application.Intefaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public ITodoItemRepository TodoItem { get; }

    public UnitOfWork(AppDbContext context, ITodoItemRepository todoItemRepository)
    {
        _context = context;
        TodoItem = todoItemRepository;
    }

    public int Commit()
    {
        return _context.SaveChanges();
    }


    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }
}
