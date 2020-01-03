using CSharpFunctionalExtensions;
using MediatR;
using System;

namespace Domain.Services.Commands
{
    public class RegisterCandidateCommand : IRequest<Result>
    {
        public RegisterCandidateCommand(string name, DateTime? birthday, string currentPosition, string note)
        {
            Name = name;
            Birthday = birthday;
            CurrentPosition = currentPosition;
            Note = note;
        }

        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string CurrentPosition { get; set; }
        public string Note { get; set; }
    }
}
