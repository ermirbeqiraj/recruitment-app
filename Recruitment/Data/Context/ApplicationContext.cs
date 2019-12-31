using Data.Configuration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            this.Database.EnsureDeleted();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppointmentConfigurations());
            builder.ApplyConfiguration(new CandidateConfigurations());
            builder.ApplyConfiguration(new ClientConfigurations());
            builder.ApplyConfiguration(new RequirementConfigurations());
            builder.ApplyConfiguration(new VacancyConfigurations());
        }
    }
}
