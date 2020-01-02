using CSharpFunctionalExtensions;
using MediatR;
using System;

namespace Domain.Services.Commands
{
    public sealed class CloseVacancyCommand : IRequest<Result>
    {
        public CloseVacancyCommand(Guid id, Guid clientId)
        {
            Id = id;
            ClientId = clientId;
        }

        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
    }
}
