using Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class ClientListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public int OpenVacancies { get; set; }
    }

    public class ClientCreateModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
    }

    public class ClientUpdateModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
    }

    public class VacancyListModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name = "Open Date")]
        public DateTime? OpenDate { get; set; }

        [Display(Name = "Close Date")]
        public DateTime? CloseDate { get; set; }
        public Guid ClientId { get; set; }
    }

    public class VacancyCreateModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name = "Open Date")]
        public DateTime? OpenDate { get; set; }

        [Display(Name = "Close Date")]
        public DateTime? CloseDate { get; set; }
    }

    public class VacancyUpdateModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name = "Open Date")]
        public DateTime? OpenDate { get; set; }

        [Display(Name = "Close Date")]
        public DateTime? CloseDate { get; set; }
    }

    public class RequirementListModel
    {
        public Guid Id { get; set; }
        public Guid VacancyId { get; set; }
        public SkillType SkillType { get; set; }
        public RequirementType RequirementType { get; set; }
        public string Content { get; set; }
    }

    public class RequirementCreateModel
    {
        public Guid VacancyId { get; set; }
        public Guid ClientId { get; set; }
        public SkillType SkillType { get; set; }
        public RequirementType RequirementType { get; set; }
        public string Content { get; set; }
    }

    public class RequirementUpdateModel
    {
        public Guid Id { get; set; }
        public Guid VacancyId { get; set; }
        public Guid ClientId { get; set; }
        public SkillType SkillType { get; set; }
        public RequirementType RequirementType { get; set; }
        public string Content { get; set; }
    }
}
