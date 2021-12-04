using System;
using System.Collections.Generic;
using Application.Commands;
using Application.Intefaces;
using MediatR;
using Microsoft.Extensions.Logging;
using WebUI.Model;

namespace Application.Handlers
{
    public class GetAllTodoItemHandler : IRequestHandler<GetAllTodoItemCommand, IEnumerable<TodoItemViewModel>>
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _uow;

        public GetAllTodoItemHandler(ILogger<GetAllTodoItemHandler> logger, IUnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }

        public async Task<IEnumerable<TodoItemViewModel>> Handle(GetAllTodoItemCommand request, CancellationToken cancellationToken)
        {
            var itens = await _uow.TodoItem.GetAll();

            _logger.LogInformation("Search {Count} itens", itens.Count());

            return itens.ToList().ConvertAll<TodoItemViewModel>(i => new TodoItemViewModel(i));
        }
    }
}

