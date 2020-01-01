using Data.Configuration;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Context
{
    public class ApplicationContext : DbContext, IUnitOfWork
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppointmentConfigurations());
            builder.ApplyConfiguration(new CandidateConfigurations());
            builder.ApplyConfiguration(new ClientConfigurations());
            builder.ApplyConfiguration(new RequirementConfigurations());
            builder.ApplyConfiguration(new VacancyConfigurations());
        }

        public async Task SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await base.SaveChangesAsync(cancellationToken);
        }
    }
}
