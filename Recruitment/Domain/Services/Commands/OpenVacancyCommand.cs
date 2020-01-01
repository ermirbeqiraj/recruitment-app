using CSharpFunctionalExtensions;
using MediatR;
using System;

namespace Domain.Services.Commands
{
    public sealed class OpenVacancyCommand : IRequest<Result>
    {
        public OpenVacancyCommand(string title, string description, DateTime? openDate, DateTime? closeDate, Guid clientId)
        {
            Title = title;
            Description = description;
            OpenDate = openDate;
            CloseDate = closeDate;
            ClientId = clientId;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public Guid ClientId { get; set; }
    }
}
