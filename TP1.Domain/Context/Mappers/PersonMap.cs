using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP1.Domain.Models;
using System;

namespace RestfullAPI.Context.Mappers
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("pn_id");

            builder.Property(t => t.Name)
                .HasColumnName("pn_name");

            builder.Property(t => t.Email)
                .HasColumnName("pn_email");

            builder.Property(t => t.SnsNumber)
                .HasColumnName("pn_sns");

            builder.Property(t => t.Active)
                .HasColumnName("pn_active");

            builder.Property(t => t.Covid)
                .HasColumnName("pn_covid");

            builder.Property(t => t.CreateDate)
                .HasColumnName("pn_createdate");

            builder.Property(t => t.ChangeDate)
             .HasColumnName("pn_changedate");

        

            builder
               .HasMany(r => r.Visits)
               .WithOne(t => t.Person)
               .HasForeignKey(r => r.PersonId);


            builder
              .HasMany(r => r.PersonContacts)
              .WithOne(t => t.ContactPerson)
              .HasForeignKey(r => r.ContactId);

            builder
             .HasMany(r => r.PersonContactInfected)
             .WithOne(t => t.Infected)
             .HasForeignKey(r => r.InfectedId);

            builder
             .HasMany(r => r.PersonCovids)
             .WithOne(t => t.Person)
             .HasForeignKey(r => r.PersonId);
        }
    }
}
