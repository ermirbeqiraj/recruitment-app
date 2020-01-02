using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Vacancy : Entity
    {
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
            Title = title;
            Description = description;
            OpenDate = openDate;
            CloseDate = closeDate;
        }

        public void AddRequirement(Requirement requirement)
        {
            _requirements.Add(requirement);
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }

        public void UpdateOpenDate(DateTime? openDate)
        {
            OpenDate = openDate;
        }

        public void UpdateCloseDate(DateTime? closeDate)
        {
            CloseDate = closeDate;
        }

        internal void RemoveRequirement(Requirement requirement)
        {
            _requirements.Remove(requirement);
        }

        internal void UpdateRequirement(Requirement requirement, Requirement newRequirement)
        {
            foreach (var item in _requirements)
            {
                if(item == requirement)
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
