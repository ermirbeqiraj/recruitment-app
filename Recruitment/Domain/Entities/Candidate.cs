using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Candidate : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public DateTime? Birthday { get; private set; }
        public string CurrentPosition { get; private set; }
        public string Note { get; private set; }

        private readonly List<Appointment> _appointments;
        public IReadOnlyList<Appointment> Appointments => _appointments;

        private Candidate()
        {
            _appointments = new List<Appointment>();
        }

        public Candidate(string name, DateTime? birthday, string currentPosition, string note) : this()
        {
            Name = name;
            Birthday = birthday;
            CurrentPosition = currentPosition;
            Note = note;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateBirthday(DateTime? birthday)
        {
            Birthday = birthday;
        }

        public void UpdateCurrentPosition(string currentPosition)
        {
            CurrentPosition = currentPosition;
        }

        public void UpdateNote(string note)
        {
            Note = note;
        }
    }
}
