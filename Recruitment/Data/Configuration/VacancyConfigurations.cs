using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    internal class VacancyConfigurations : IEntityTypeConfiguration<Vacancy>
    {
        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.HasKey(x => x.Id);

            var requirementsNavigation = builder.Metadata.FindNavigation(nameof(Vacancy.Requirements));
            requirementsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).HasMaxLength(1000);
        }
    }
}
