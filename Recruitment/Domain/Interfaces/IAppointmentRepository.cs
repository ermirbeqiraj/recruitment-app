using Domain.Common;
using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment> 
    {
        Task<Appointment> Get(Guid id);
        void Add(Appointment model);
        void Update(Appointment model);
        void Remove(Appointment model);
    }
}
