using CSharpFunctionalExtensions;
using MediatR;
using System;

namespace Domain.Services.Commands
{
    public sealed class RemoveRequirementCommand : IRequest<Result>
    {
        public RemoveRequirementCommand(Guid id, Guid clientId, Guid vacancyId)
        {
            Id = id;
            VacancyId = vacancyId;
            ClientId = clientId;
        }

        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid VacancyId { get; set; }
    }
}
