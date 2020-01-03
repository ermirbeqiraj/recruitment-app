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
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public AppointmentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Appointment> Get(Guid id)
        {
            return await _context.Appointments.Include(x => x.Candidate).Include(x => x.Vacancy).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void Add(Appointment model)
        {
            _context.Add(model);
        }

        public void Update(Appointment model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }

        public void Remove(Appointment model)
        {
            _context.Remove(model);
        }
    }
}
