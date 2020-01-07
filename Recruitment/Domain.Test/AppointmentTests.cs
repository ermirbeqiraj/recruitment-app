using Domain.Constants;
using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Domain.Test
{
    public class AppointmentTests
    {
        dynamic data = new
        {
            AppointmentType = AppointmentType.Phone,
            StartsAt = DateTime.Now.AddHours(1),
            Candidate = new Candidate(new CandidateName("John", "Doe"), DateTime.Now.AddYears(-30), "C# developer", "Never contacted before"),
            Vacancy = new Vacancy("C# Developer", "Preffered with side ruby history", DateTime.Now, DateTime.Now.AddMonths(1))
        };

        [Fact]
        public void Should_Create_Successfuly()
        {
            var appointment = new Appointment(AppointmentType.Phone, data.StartsAt, data.Candidate, data.Vacancy);

            Assert.Equal(data.AppointmentType, appointment.AppointmentType);
            Assert.Equal(data.StartsAt, appointment.StartsAt);
            Assert.Equal(data.Candidate, appointment.Candidate);
            Assert.Equal(data.Vacancy, appointment.Vacancy);
        }

        [Fact]
        public void Should_Update_StartDate()
        {
            var appointment = new Appointment(AppointmentType.Phone, data.StartsAt, data.Candidate, data.Vacancy);
            var startsAt = appointment.StartsAt.AddDays(1);
            appointment.UpdateStartsAt(startsAt);
            Assert.Equal(startsAt, appointment.StartsAt);
        }

        [Fact]
        public void Should_Update_Type()
        {
            var appointment = new Appointment(AppointmentType.Phone, data.StartsAt, data.Candidate, data.Vacancy);

            appointment.UpdateAppointmentType(AppointmentType.VideoCall);

            Assert.Equal(AppointmentType.VideoCall, appointment.AppointmentType);
        }

        [Fact]
        public void Should_Update_Candidate()
        {
            var appointment = new Appointment(AppointmentType.Phone, data.StartsAt, data.Candidate, data.Vacancy);
            var newCandidate = new Candidate(new CandidateName("John", "Smith"), null, null, null);

            appointment.UpdateCandidate(newCandidate);

            Assert.Equal(newCandidate, appointment.Candidate);
        }

        [Fact]
        public void Should_Update_Vacancy()
        {
            var appointment = new Appointment(AppointmentType.Phone, data.StartsAt, data.Candidate, data.Vacancy);
            var newVacancy = new Vacancy("Dotnet Backend Developer", "Some description", null, null);

            appointment.UpdateVacancy(newVacancy);

            Assert.Equal(newVacancy, appointment.Vacancy);
        }
    }
}
