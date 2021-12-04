using MediatR;

namespace Application.Commands;

public record CreateTodoItemCommand(Guid Id, string Name, bool IsFinished) : IRequest<Guid>;