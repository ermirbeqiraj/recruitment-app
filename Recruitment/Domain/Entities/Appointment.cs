using Domain.Common;
using Domain.Constants;
using System;

namespace Domain.Entities
{
    public class Appointment : Entity, IAggregateRoot
    {
        public AppointmentType AppointmentType { get; private set; }
        public DateTime StartsAt { get; private set; }
        public Candidate Candidate { get; private set; }
        public Vacancy Vacancy { get; private set; }

        public Appointment(AppointmentType type, DateTime startsAt, Candidate withCandidate, Vacancy forVacancy)
        {
            AppointmentType = type;
            StartsAt = startsAt;
            Candidate = withCandidate;
            Vacancy = forVacancy;
        }
    }
}
