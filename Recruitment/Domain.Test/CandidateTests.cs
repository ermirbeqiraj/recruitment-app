using Domain.Entities;
using Domain.ValueObjects;
using System;
using Xunit;

namespace Domain.Test
{
    public class CandidateTests
    {
        [Fact]
        public void Should_Create_Successfully()
        {
            var data = new
            {
                FirstName = "John",
                LastName = "Doe",
                Position = ".net developer",
                Birthday = new DateTime(1990, 11, 07),
                Note = "Contacted"
            };

            var candidate = new Candidate(new CandidateName(data.FirstName, data.LastName), data.Birthday, data.Position, data.Note);

            Assert.Equal(data.Note, candidate.Note);
            Assert.Equal(data.Birthday, candidate.Birthday);
            Assert.Equal(data.Position, candidate.CurrentPosition);
            Assert.Equal(new CandidateName(data.FirstName, data.LastName), candidate.CandidateName);
        }

        [Fact]
        public void Should_Throw_Null_Exception()
        {
            var data = new
            {
                Position = ".net developer",
                Birthday = new DateTime(1990, 11, 07),
                Note = "Contacted"
            };

            Assert.Throws<ArgumentNullException>(() => new Candidate(new CandidateName(null, "last"), data.Birthday, data.Position, data.Note));
            Assert.Throws<ArgumentNullException>(() => new Candidate(new CandidateName("First", null), data.Birthday, data.Position, data.Note));
            Assert.Throws<ArgumentNullException>(() => new Candidate(new CandidateName(null, null), data.Birthday, data.Position, data.Note));
        }

        [Fact]
        public void Should_Throw_Argument_Exception()
        {
            var data = new
            {
                First = "thisismorethan50charslongoffcoursethisismorethan50c",
                Last = "thisismorethan50charslongoffcoursethisismorethan50c",
                Position = ".net developer",
                Birthday = new DateTime(1990, 11, 07),
                Note = "Contacted"
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => new Candidate(new CandidateName(data.First, "last"), data.Birthday, data.Position, data.Note));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Candidate(new CandidateName("First", data.Last), data.Birthday, data.Position, data.Note));
        }
    }
}
