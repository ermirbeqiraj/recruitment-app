using Domain.Common;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICandidateRepository : IRepository<Candidate> 
    {
        void Add(Candidate model);
        void Update(Candidate model);
        void Remove(Candidate model);
    }
}
