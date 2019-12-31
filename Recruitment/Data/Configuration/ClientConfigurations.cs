using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    internal class ClientConfigurations : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);

            // prop access

            var vacancyNavigation = builder.Metadata.FindNavigation(nameof(Client.Vacancies));
            vacancyNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Website).HasMaxLength(150);
            builder.Property(x => x.Description).HasMaxLength(1000);
        }
    }
}
