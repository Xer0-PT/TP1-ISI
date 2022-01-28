using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP1.Domain.Models;
using System;

namespace RestfullAPI.Context.Mappers
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("pt_id");

            builder.Property(t => t.Name)
                .HasColumnName("pt_name");

            builder.Property(t => t.Price)
                .HasColumnName("pt_price");

            builder.Property(t => t.Stock)
                .HasColumnName("pt_stock");

            builder.Property(t => t.Active)
                .HasColumnName("pt_active");

            builder.Property(t => t.CreateDate)
                .HasColumnName("pt_createdate");

            builder.Property(t => t.ChangeDate)
             .HasColumnName("pt_changedate");

            //FK

            builder
               .HasMany(r => r.RequisitionProducts)
               .WithOne(t => t.Product)
               .HasForeignKey(r => r.ProductId);
        }
    }
}
