using Domain.Common;
using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClientRepository : IRepository<Client> 
    {
        Task<Client> Get(Guid id);
        Task<Client> GetByVacancy(Guid vacancyId);
        void Add(Client model);
        void Update(Client model);
        void Remove(Client model);
    }
}
