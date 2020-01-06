using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class CandidateListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string CurrentPosition { get; set; }
        public string Note { get; set; }
    }

    public class CandidateRegisterModel
    {
        [Display(Name = "First Name")]
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }

        [Display(Name = "Current Position")]
        [MaxLength(100)]
        public string CurrentPosition { get; set; }

        [MaxLength(1000)]
        public string Note { get; set; }
    }

    public class CandidateModifyModel
    {
        public Guid Id { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }

        [Display(Name = "Current Position")]
        [MaxLength(100)]
        public string CurrentPosition { get; set; }

        [MaxLength(1000)]
        public string Note { get; set; }
    }
}
