using Domain.Common;
using Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;

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

        internal void UpdateRequirement(Guid id, string content, SkillType skillType, RequirementType requirementType)
        {
            var found = _requirements.Where(x => x.Id == id).Any();

            if (!found)
                throw new ArgumentException("Requirement doesn't exists!");

            foreach (var item in _requirements)
            {
                if (item.Id == id)
                {
                    item.UpdateContent(content);
                    item.UpdateRequirementType(requirementType);
                    item.UpdateSkillType(skillType);

                    break;
                }
            }
        }

        internal void RemoveRequirement(Guid id)
        {
            var requirement = _requirements.Where(x => x.Id == id).FirstOrDefault();

            if (requirement == null)
                throw new ArgumentException("Requirement doesn't exists!");

            _requirements.Remove(requirement);
        }
    }
}
