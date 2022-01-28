using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP1.Domain.Models;

namespace RestfullAPI.Context.Mappers
{
    public class RequisitionProductMap : IEntityTypeConfiguration<RequisitionProduct>
    {
        public void Configure(EntityTypeBuilder<RequisitionProduct> builder)
        {
            builder.ToTable("RequisitionProduct");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("rqp_id");

            builder.Property(t => t.RequisitionId)
                .HasColumnName("rqp_rq_id");

            builder.Property(t => t.ProductId)
               .HasColumnName("rqp_pt_id");

            builder.Property(t => t.Quantity)
               .HasColumnName("rqp_quantity");

            builder.Property(t => t.CreateDate)
                .HasColumnName("rqp_createdate");

        }
    }
}
