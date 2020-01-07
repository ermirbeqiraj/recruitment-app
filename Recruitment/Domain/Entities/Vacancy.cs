using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Vacancy : Entity
    {
        private const int TITLE_LEN = 200;
        private const int DESCRIPTION_LEN = 1000;

        private readonly List<Requirement> _requirements;
        public IReadOnlyList<Requirement> Requirements => _requirements;
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime? OpenDate { get; private set; }
        public DateTime? CloseDate { get; private set; }

        private Vacancy()
        {
            _requirements = new List<Requirement>();
        }

        public Vacancy(string title, string description, DateTime? openDate, DateTime? closeDate) : this()
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title));

            if (title.Length > TITLE_LEN)
                throw new ArgumentOutOfRangeException(nameof(title), $"Should not be more than {TITLE_LEN} characters");

            if (!string.IsNullOrWhiteSpace(description) && description.Length > DESCRIPTION_LEN)
                throw new ArgumentOutOfRangeException(nameof(description), $"Should not be more than {DESCRIPTION_LEN} characters");

            if (openDate.HasValue && closeDate.HasValue && openDate.Value > closeDate.Value)
                throw new Exception($"{nameof(openDate)} can't be after {nameof(closeDate)}");

            Title = title;
            Description = description;
            OpenDate = openDate;
            CloseDate = closeDate;
        }

        public void UpdateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title));

            if (title.Length > TITLE_LEN)
                throw new ArgumentOutOfRangeException(nameof(title), $"Should not be more than {TITLE_LEN} characters");

            Title = title;
        }

        public void UpdateDescription(string description)
        {
            if (!string.IsNullOrWhiteSpace(description) && description.Length > DESCRIPTION_LEN)
                throw new ArgumentOutOfRangeException(nameof(description), $"Should not be more than {DESCRIPTION_LEN} characters");

            Description = description;
        }

        public void UpdateOpenDate(DateTime? openDate)
        {
            if (openDate.HasValue && CloseDate.HasValue && openDate.Value > CloseDate.Value)
                throw new Exception($"{nameof(openDate)} can't be after {nameof(CloseDate)}");

            OpenDate = openDate;
        }

        public void UpdateCloseDate(DateTime? closeDate)
        {
            if (OpenDate.HasValue && closeDate.HasValue && OpenDate.Value > closeDate.Value)
                throw new Exception($"{nameof(closeDate)} should be after {nameof(OpenDate)}");

            CloseDate = closeDate;
        }

        internal void AddRequirement(Requirement requirement)
        {
            _requirements.Add(requirement);
        }

        internal void RemoveRequirement(Requirement requirement)
        {
            _requirements.Remove(requirement);
        }

        internal void UpdateRequirement(Requirement requirement, Requirement newRequirement)
        {
            foreach (var item in _requirements)
            {
                if (item == requirement)
                {
                    item.UpdateContent(newRequirement.Content);
                    item.UpdateRequirementType(newRequirement.RequirementType);
                    item.UpdateSkillType(newRequirement.SkillType);

                    break;
                }
            }
        }
    }
}
