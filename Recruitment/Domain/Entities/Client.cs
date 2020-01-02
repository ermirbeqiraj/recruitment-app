using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Client : Entity, IAggregateRoot
    {
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
            Name = name;
            Website = website;
            Description = description;
        }

        public void AddVacancy(Vacancy vacancy)
        {
            _vacancies.Add(vacancy);
        }

        public void UpdateVacancy(Guid id, string title, string description, DateTime? openDate, DateTime? closeDate)
        {
            var found = _vacancies.Where(x => x.Id == id).Any();

            if (!found)
                throw new ArgumentException("Vacancy that you are trying to update doesn't exists!");

            foreach (var item in _vacancies)
            {
                if(item.Id == id)
                {
                    item.UpdateTitle(title);
                    item.UpdateDescription(description);
                    item.UpdateOpenDate(openDate);
                    item.UpdateCloseDate(closeDate);

                    break;
                }
            }
        }

        public void CloseVacancy(Guid id)
        {
            var vacancyExists = _vacancies.Where(x => x.Id == id).Any();

            if (!vacancyExists)
                throw new ArgumentException("Vacancy that you are trying to close doesn't exists!");

            foreach (var item in _vacancies)
            {
                if (item.Id == id)
                {
                    item.UpdateCloseDate(DateTime.Now);

                    break;
                }
            }
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
    }
}
