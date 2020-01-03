using Data.Context;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public CandidateRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Candidate> Get(Guid id)
        {
            return await _context.Candidates.Where(x => x.Id == id).Include(x => x.Appointments).FirstOrDefaultAsync();
        }

        public void Add(Candidate model)
        {
            _context.Add(model);
        }

        public void Remove(Candidate model)
        {
            _context.Remove(model);
        }

        public void Update(Candidate model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}
