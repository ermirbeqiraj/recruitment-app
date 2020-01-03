using CSharpFunctionalExtensions;
using Domain.Constants;
using MediatR;
using System;

namespace Domain.Services.Commands
{
    public sealed class UpdateAppointmentCommand : IRequest<Result>
    {
        public UpdateAppointmentCommand(Guid id, AppointmentType appointmentType, DateTime startsAt, Guid candidateId, Guid vacancyId)
        {
            Id = id;
            AppointmentType = appointmentType;
            StartsAt = startsAt;
            CandidateId = candidateId;
            VacancyId = vacancyId;
        }

        public Guid Id { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public DateTime StartsAt { get; set; }
        public Guid CandidateId { get; set; }
        public Guid VacancyId { get; set; }
    }
}
