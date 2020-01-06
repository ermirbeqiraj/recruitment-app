using Domain.Common;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Candidate : Entity, IAggregateRoot
    {
        private const int CURRENT_POSITION_LEN = 100;
        private const int NOTE_LEN = 1000;

        public CandidateName CandidateName { get; private set; }
        public DateTime? Birthday { get; private set; }
        public string CurrentPosition { get; private set; }
        public string Note { get; private set; }

        private readonly List<Appointment> _appointments;
        public IReadOnlyList<Appointment> Appointments => _appointments;

        private Candidate()
        {
            _appointments = new List<Appointment>();
        }

        public Candidate(CandidateName name, DateTime? birthday, string currentPosition, string note) : this()
        {
            if (!string.IsNullOrEmpty(currentPosition) && currentPosition.Length > CURRENT_POSITION_LEN)
                throw new ArgumentOutOfRangeException(nameof(currentPosition), $"Should not be more than {CURRENT_POSITION_LEN}");

            if (!string.IsNullOrEmpty(note) && note.Length > NOTE_LEN)
                throw new ArgumentOutOfRangeException(nameof(note), $"Should not be more than {NOTE_LEN}");

            CandidateName = name;
            Birthday = birthday;
            CurrentPosition = currentPosition;
            Note = note;
        }

        public void UpdateName(CandidateName name)
        {
            CandidateName = name;
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
