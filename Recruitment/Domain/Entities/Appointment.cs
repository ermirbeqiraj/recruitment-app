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

        private Appointment() { }
        public Appointment(AppointmentType type, DateTime startsAt, Candidate withCandidate, Vacancy forVacancy) : this()
        {
            AppointmentType = type;
            StartsAt = startsAt;
            Candidate = withCandidate;
            Vacancy = forVacancy;
        }

        public void UpdateStartsAt(DateTime startsAt)
        {
            StartsAt = startsAt;
        }

        public void UpdateAppointmentType(AppointmentType appointmentType)
        {
            AppointmentType = appointmentType;
        }

        public void UpdateCandidate(Candidate candidate)
        {
            Candidate = candidate;
        }

        public void UpdateVacancy(Vacancy vacancy)
        {
            Vacancy = vacancy;
        }
    }
}
