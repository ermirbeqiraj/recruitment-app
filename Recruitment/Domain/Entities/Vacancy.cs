using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Vacancy : Entity
    {
        private readonly List<Requirements> _requirements;
        public IReadOnlyList<Requirements> Requirements => _requirements;
        public string Title { get; private set; }
        public DateTime? OpenDate { get; private set; }
        public DateTime? CloseDate { get; private set; }

        private Vacancy()
        {
            _requirements = new List<Requirements>();
        }

        public Vacancy(string title, DateTime openDate, DateTime closeDate) : this()
        {
            Title = title;
            OpenDate = openDate;
            CloseDate = closeDate;
        }
    }
}
