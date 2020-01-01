using Data.Context;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;

namespace Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ClientRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Client model)
        {
            _context.Add(model);
        }

        public void Remove(Client model)
        {
            _context.Remove(model);
        }

        public void Update(Client model)
        {
            _context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
