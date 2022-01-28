using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP1.Domain.Models;

namespace RestfullAPI.Context.Mappers
{
    public class VisitMap : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.ToTable("Visit");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("vs_id");

            builder.Property(t => t.PersonId)
                .HasColumnName("vs_pn_id");

            builder.Property(t => t.PoliceId)
                .HasColumnName("vs_police_id");

            builder.Property(t => t.DateOfVisit)
                .HasColumnName("vs_dateofvisit");

            builder.Property(t => t.Transgressions)
                .HasColumnName("vs_transgressions");

            //FK

            builder
                 .HasOne(c => c.Person)
                 .WithMany(pc => pc.Visits)
                 .HasForeignKey(pc => pc.PersonId);


        }
    }
}
