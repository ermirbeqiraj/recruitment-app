﻿using Domain.Common;
using System.Collections.Generic;

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
