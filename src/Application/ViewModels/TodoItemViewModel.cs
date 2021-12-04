using System.Text.Json.Serialization;
using Application.Commands;
using Domain.Entities;
using FluentValidation;

namespace WebUI.Model
{
    public class TodoItemViewModel
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public bool IsFinished { get; set; } = false;

        [JsonConstructor]
        public TodoItemViewModel(string name, bool isFinished) =>
        (Id, Name, IsFinished) = (Guid.NewGuid(), name, isFinished);

        public TodoItemViewModel(TodoItem item)
        {
            Id = item.Id;
            Name = item.Name;
            IsFinished = item.IsFinished;          
        }

        public CreateTodoItemCommand ToCommand() =>
            new(Id, Name, IsFinished);
    }

    public class TodoItemValidator : AbstractValidator<TodoItemViewModel>
    {
        public TodoItemValidator()
        {
            RuleFor(i => i.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5);
        }
    }
}