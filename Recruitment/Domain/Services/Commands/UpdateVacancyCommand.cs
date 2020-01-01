using CSharpFunctionalExtensions;
using MediatR;
using System;

namespace Domain.Services.Commands
{
    public sealed class UpdateVacancyCommand : IRequest<Result>
    {
        public UpdateVacancyCommand(Guid id,Guid clientId, string title, string description, DateTime? openDate, DateTime? closeDate)
        {
            Id = id;
            ClientId = clientId;
            Title = title;
            Description = description;
            OpenDate = openDate;
            CloseDate = closeDate;
        }

        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime? OpenDate { get; private set; }
        public DateTime? CloseDate { get; private set; }
    }
}
