using Domain.Common;
using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICandidateRepository : IRepository<Candidate> 
    {
        Task<Candidate> Get(Guid id);
        void Add(Candidate model);
        void Update(Candidate model);
        void Remove(Candidate model);
    }
}
