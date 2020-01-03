using CSharpFunctionalExtensions;
using Domain.Constants;
using MediatR;
using System;

namespace Domain.Services.Commands
{
    public sealed class MakeAppointmentCommand : IRequest<Result>
    {
        public MakeAppointmentCommand(AppointmentType appointmentType, DateTime startsAt, Guid candidateId, Guid vacancyId)
        {
            AppointmentType = appointmentType;
            StartsAt = startsAt;
            CandidateId = candidateId;
            VacancyId = vacancyId;
        }

        public AppointmentType AppointmentType { get; set; }
        public DateTime StartsAt { get; set; }
        public Guid CandidateId { get; set; }
        public Guid VacancyId { get; set; }
    }
}
