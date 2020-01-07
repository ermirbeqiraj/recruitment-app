using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Domain.Test")]
namespace Domain.Entities
{
    public class Client : Entity, IAggregateRoot
    {
        private const int NAME_LEN = 100;
        private const int WEBSITE_LEN = 150;
        private const int DESCRIPTION_LEN = 1000;

        private readonly List<Vacancy> _vacancies;
        public IReadOnlyList<Vacancy> Vacancies => _vacancies;
        public string Name { get; private set; }
        public string Website { get; private set; }
        public string Description { get; private set; }

        private Client()
        {
            _vacancies = new List<Vacancy>();
        }

        public Client(string name, string website, string description) : this()
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            if (name.Length > NAME_LEN)
                throw new ArgumentOutOfRangeException(nameof(name), $"{nameof(name)} should not be more than {NAME_LEN} characters");

            if(!string.IsNullOrWhiteSpace(website) && website.Length > WEBSITE_LEN)
                throw new ArgumentOutOfRangeException(nameof(website), $"{nameof(website)} should not be more than {WEBSITE_LEN} characters");

            if (!string.IsNullOrWhiteSpace(description) && description.Length > DESCRIPTION_LEN)
                throw new ArgumentOutOfRangeException(nameof(description), $"{nameof(description)} should not be more than {DESCRIPTION_LEN} characters");

            Name = name;
            Website = website;
            Description = description;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateWebsite(string website)
        {
            Website = website;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }

        public void AddVacancy(Vacancy vacancy)
        {
            _vacancies.Add(vacancy);
        }

        public void UpdateVacancy(Vacancy vacancy, string title, string description, DateTime? openDate, DateTime? closeDate)
        {
            foreach (var item in _vacancies)
            {
                if (item == vacancy)
                {
                    item.UpdateTitle(title);
                    item.UpdateDescription(description);
                    item.UpdateOpenDate(openDate);
                    item.UpdateCloseDate(closeDate);

                    break;
                }
            }
        }

        public void CloseVacancy(Vacancy vacancy)
        {
            foreach (var item in _vacancies)
            {
                if (item == vacancy)
                {
                    item.UpdateCloseDate(DateTime.Now);
                    break;
                }
            }
        }

        public void UpdateRequirement(Vacancy vacancy, Requirement requirement, Requirement newRequirement)
        {
            foreach (var item in _vacancies)
            {
                if (item == vacancy)
                {
                    item.UpdateRequirement(requirement, newRequirement);
                    break;
                }
            }
        }

        public void RemoveRequirement(Requirement requirement)
        {
            foreach (var item in _vacancies)
            {
                if (item.Requirements.Where(x => x == requirement).Any())
                {
                    item.RemoveRequirement(requirement);
                    break;
                }
            }
        }

        public void AddRequirementOnVacancy(Vacancy vacancy, Requirement requirement)
        {
            foreach (var item in _vacancies)
            {
                if (item == vacancy)
                {
                    item.AddRequirement(requirement);
                    break;
                }
            }
        }
    }
}
