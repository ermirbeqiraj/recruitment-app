using Domain.Constants;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class AppointmentListModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Appointment Type")]
        public AppointmentType AppointmentType { get; set; }
        [Display(Name = "Starts At")]
        public DateTime StartsAt { get; set; }

        [Display(Name = "Candidate")]
        public string CandidateName { get; set; }

        [Display(Name = "Vacancy")]
        public string VacancyTitle { get; set; }
    }

    public class MakeAppointmentModel
    {
        [Required]
        [Display(Name = "Type")]
        public AppointmentType AppointmentType { get; set; }

        [Required]
        [Display(Name = "Starts At")]
        public DateTime StartsAt { get; set; }

        [Required]
        [Display(Name = "Candidate")]
        public Guid CandidateId { get; set; }

        [Required]
        [Display(Name = "Vacancy")]
        public Guid VacancyId { get; set; }

        public SelectList Candidates { get; set; }
        public SelectList Vacancies { get; set; }
    }

    public class UpdateAppointmentModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Type")]
        public AppointmentType AppointmentType { get; set; }

        [Required]
        [Display(Name = "Starts At")]
        public DateTime StartsAt { get; set; }

        [Required]
        [Display(Name = "Candidate")]
        public Guid CandidateId { get; set; }

        [Required]
        [Display(Name = "Vacancy")]
        public Guid VacancyId { get; set; }

        public SelectList Candidates { get; set; }
        public SelectList Vacancies { get; set; }
    }
}
