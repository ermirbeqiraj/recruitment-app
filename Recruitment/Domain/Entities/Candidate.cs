using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Candidate : Entity, IAggregateRoot
    {
        private const int NAME_LEN = 100;
        private const int CURRENT_POSITION_LEN = 100;
        private const int NOTE_LEN = 1000;

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
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (name.Length > NAME_LEN)
                throw new ArgumentOutOfRangeException(nameof(name), $"Should not be more than {NAME_LEN} characters");

            if (!string.IsNullOrEmpty(currentPosition) && currentPosition.Length > CURRENT_POSITION_LEN)
                throw new ArgumentOutOfRangeException(nameof(currentPosition), $"Should not be more than {CURRENT_POSITION_LEN}");

            if (!string.IsNullOrEmpty(note) && note.Length > NOTE_LEN)
                throw new ArgumentOutOfRangeException(nameof(note), $"Should not be more than {NOTE_LEN}");

            Name = name;
            Birthday = birthday;
            CurrentPosition = currentPosition;
            Note = note;
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (name.Length > NAME_LEN)
                throw new ArgumentOutOfRangeException(nameof(name), $"Should not be more than {NAME_LEN} characters");

            Name = name;
        }

        public void UpdateBirthday(DateTime? birthday)
        {
            Birthday = birthday;
        }

        public void UpdateCurrentPosition(string currentPosition)
        {
            if (!string.IsNullOrEmpty(currentPosition) && currentPosition.Length > CURRENT_POSITION_LEN)
                throw new ArgumentOutOfRangeException(nameof(currentPosition), $"Should not be more than {CURRENT_POSITION_LEN}");

            CurrentPosition = currentPosition;
        }

        public void UpdateNote(string note)
        {
            if (!string.IsNullOrEmpty(note) && note.Length > NOTE_LEN)
                throw new ArgumentOutOfRangeException(nameof(note), $"Should not be more than {NOTE_LEN}");

            Note = note;
        }
    }
}
