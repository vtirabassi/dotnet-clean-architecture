using MediatR;
using WebUI.Model;

namespace Application.Commands
{
    public record GetAllTodoItemCommand() : IRequest<IEnumerable<TodoItemViewModel>>;
}

