using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP1.Domain.Models;
using System;

namespace RestfullAPI.Context.Mappers
{
    public class RequisitionMap : IEntityTypeConfiguration<Requisition>
    {
        public void Configure(EntityTypeBuilder<Requisition> builder)
        {
            builder.ToTable("Requisition");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("rq_id");

            builder.Property(t => t.TeamId)
                .HasColumnName("rq_tm_id");

            builder.Property(t => t.Processed)
                .HasColumnName("rq_processed");

            builder.Property(t => t.CreateDate)
                .HasColumnName("rq_createdate");

            builder.Property(t => t.ChangeDate)
                .HasColumnName("rq_changedate");

            //FK

            builder
              .HasMany(r => r.RequisitionProducts)
              .WithOne(t => t.Requisition)
              .HasForeignKey(r => r.RequisitionId);

        }
    }
}
