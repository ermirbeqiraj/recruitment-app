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

        public Vacancy(string title, string description, DateTime openDate, DateTime closeDate) : this()
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
    }
}
