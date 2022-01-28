using Microsoft.EntityFrameworkCore;
using RestfullAPI.Context.Mappers;
using TP1.Domain.Context.Mappers;
using TP1.Domain.Models;

namespace TP1.Domain.Context
{
    public class DataContext : DbContext
    {
  
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Requisition> Requisitions { get; set; }
        public DbSet<RequisitionProduct> RequisitionProducts { get; set; }
        public DbSet<Person> Persons { get; set; }

        public DbSet<PersonContact> PersonContacts { get; set; }

        public DbSet<PersonCovid> PersonCovids { get; set; }

        public DbSet<Visit> Visits { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=password;");

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("db");
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new TeamMap());
            builder.ApplyConfiguration(new RequisitionMap());
            builder.ApplyConfiguration(new RequisitionProductMap());
            builder.ApplyConfiguration(new PersonMap());
            builder.ApplyConfiguration(new PersonContactMap());
            builder.ApplyConfiguration(new PersonCovidMap());
            builder.ApplyConfiguration(new VisitMap());
        }


    }
}
