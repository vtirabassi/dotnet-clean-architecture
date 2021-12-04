using System;
namespace Domain.Entities
{
    public class TodoItem
    {
        public TodoItem(Guid id, string name, bool isFinished)
        {
            Id = id;
            Name = name;
            IsFinished = isFinished;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsFinished { get; set; }
    }
}

