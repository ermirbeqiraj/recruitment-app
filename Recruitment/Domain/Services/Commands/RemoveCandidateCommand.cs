using CSharpFunctionalExtensions;
using MediatR;
using System;

namespace Domain.Services.Commands
{
    public sealed class RemoveCandidateCommand : IRequest<Result>
    {
        public RemoveCandidateCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
