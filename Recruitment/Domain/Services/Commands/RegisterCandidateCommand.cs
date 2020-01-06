using CSharpFunctionalExtensions;
using MediatR;
using System;

namespace Domain.Services.Commands
{
    public class RegisterCandidateCommand : IRequest<Result>
    {
        public RegisterCandidateCommand(string firstName, string lastName, DateTime? birthday, string currentPosition, string note)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            CurrentPosition = currentPosition;
            Note = note;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string CurrentPosition { get; set; }
        public string Note { get; set; }
    }
}
