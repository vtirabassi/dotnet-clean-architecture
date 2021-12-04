using System;
using Domain.Commons;

namespace Domain.Events
{
    public class ErrorEvent : DomainEvent
    {
        public ErrorEvent(string error, string stackTrace)
        {
            Error = error;
            StackTrace = stackTrace;
        }

        public string Error { get; }
        public string StackTrace { get; }
    }
}

