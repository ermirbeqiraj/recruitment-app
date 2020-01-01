using Domain.Common;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClientRepository : IRepository<Client> 
    {

        void Add(Client model);
        void Update(Client model);
        void Remove(Client model);
    }
}
