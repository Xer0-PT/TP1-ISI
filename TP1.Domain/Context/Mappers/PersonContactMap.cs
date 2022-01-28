using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP1.Domain.Models;

namespace TP1.Domain.Context.Mappers
{
    public class PersonContactMap : IEntityTypeConfiguration<PersonContact>
    {
        public void Configure(EntityTypeBuilder<PersonContact> builder)
        {
            builder.ToTable("PersonContact");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("pnc_id");

            builder.Property(t => t.InfectedId)
                .HasColumnName("pnc_infected_id");

            builder.Property(t => t.ContactId)
                .HasColumnName("pnc_contact_id");

            builder.Property(t => t.Date)
                .HasColumnName("pnc_date");

            builder.Property(t => t.CreateDate)
                .HasColumnName("pnc_createdate");

            //FK


            builder
                 .HasOne(c => c.ContactPerson)
                 .WithMany(pc => pc.PersonContacts)
                 .HasForeignKey(pc => pc.ContactId);

            builder
                 .HasOne(i => i.Infected)
                 .WithMany(pc => pc.PersonContactInfected)
                 .HasForeignKey(pc => pc.InfectedId);


        }

      
    }
}
