using Domain.Common;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment> 
    {
        void Add(Appointment model);
        void Update(Appointment model);
        void Remove(Appointment model);
    }
}
