using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    internal class CandidateConfigurations : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasKey(x => x.Id);

            // prop access
            var appointmentNav = builder.Metadata.FindNavigation(nameof(Candidate.Appointments));
            appointmentNav.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CurrentPosition).HasMaxLength(100);
            builder.Property(x => x.Note).HasMaxLength(1000);
        }
    }
}
