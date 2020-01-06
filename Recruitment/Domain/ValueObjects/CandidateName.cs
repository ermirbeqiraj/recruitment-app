using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.ValueObjects
{
    public class CandidateName : ValueObject
    {
        private const int FIRST_NAME_LEN = 50;
        private const int LAST_NAME_LEN = 50;

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public CandidateName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException(nameof(firstName));

            if (firstName.Length > FIRST_NAME_LEN)
                throw new ArgumentOutOfRangeException(nameof(firstName));

            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException(nameof(lastName));

            if (lastName.Length > LAST_NAME_LEN)
                throw new ArgumentOutOfRangeException(nameof(lastName));

            FirstName = firstName;
            LastName = lastName;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
