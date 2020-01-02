﻿using Data.Context;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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
            _context.Entry(model).State = EntityState.Modified;
        }

        public async Task<Client> Get(Guid id)
        {
            var client = await _context.Clients.Where(x => x.Id == id)
                                    .Include(v => v.Vacancies)
                                    .ThenInclude(r => r.Requirements)
                                    .FirstOrDefaultAsync();

            return client;
        }

        public async Task<Client> GetByVacancy(Guid vacancyId)
        {
            var client = await _context.Clients.Where(x => x.Vacancies.Any(v => v.Id == vacancyId))
                                .Include(v => v.Vacancies)
                                .ThenInclude(r => r.Requirements)
                                .FirstOrDefaultAsync();

            return client;
        }
    }
}
