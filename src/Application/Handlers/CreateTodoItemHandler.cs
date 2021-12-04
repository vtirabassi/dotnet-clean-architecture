using Application.Commands;
using Application.Intefaces;
using Domain.Entities;
using Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handles
{
    public class CreateTodoItemHandler : IRequestHandler<CreateTodoItemCommand, Guid>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _uow;

        public CreateTodoItemHandler(ILogger<CreateTodoItemHandler> logger, IMediator mediator, IUnitOfWork uow)
        {
            _logger = logger;
            _mediator = mediator;
            _uow = uow;
        }

        public async Task<Guid> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoItem(request.Id, request.Name, request.IsFinished);
            _logger.BeginScope("{Id}", request.Id);

            try
            {
                await _uow.TodoItem.Add(entity);
                var @event = new CreatedTodoItemEvent(entity, true);
                
                await _mediator.Publish(new DomainEventNotification<CreatedTodoItemEvent>(@event), cancellationToken);

                _uow.Commit();

                _logger.LogInformation("Item salved at {Hour}", DateTime.UtcNow);
                return await Task.FromResult(entity.Id);

            }
            catch (Exception ex)
            {
                await _mediator.Publish(new CreatedTodoItemEvent(entity, false), cancellationToken);
                await _mediator.Publish(new ErrorEvent(ex.Message, stackTrace: ex.StackTrace), cancellationToken);

                _logger.LogError(ex, "Error occurred");

                return await Task.FromResult(entity.Id);
            }
        }
    }
}