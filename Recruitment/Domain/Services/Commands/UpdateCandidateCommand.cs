using CSharpFunctionalExtensions;
using MediatR;
using System;

namespace Domain.Services.Commands
{
    public sealed class UpdateCandidateCommand : IRequest<Result>
    {
        public UpdateCandidateCommand(Guid id, string firstName, string lastName, DateTime? birthday, string currentPosition, string note)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            CurrentPosition = currentPosition;
            Note = note;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string CurrentPosition { get; set; }
        public string Note { get; set; }
    }
}
