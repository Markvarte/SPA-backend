using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Task2_restAPI.Models
{
    public class ModelContext : DbContext 
    {
        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public DbSet<House> Houses { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>().HasKey(x => x.Id); // configure primary key (fluend configuration )
            modelBuilder.Entity<Flat>().HasKey(x => x.Id); // configure primary key 
            modelBuilder.Entity<Tenant>().HasKey(x => x.Id); // configure primary key 
            // if neccessary there also might be something like 
            //modelBuilder.Entity<Department>().Property(t => t.DepartmentID)
            // .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            // souce -> https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/types-and-properties

            //modelBuilder.Entity<House>() // solution for auto increment houses id
            //    .Property(h => h.Id) // valueGeneratedOnAdd();
            //    .HasDefaultValueSql("newId()");

            modelBuilder.Entity<House>()
                .HasMany(h => h.Flats)
                .WithOne(i => i.House)
                .HasForeignKey(f => f.HouseId);

            modelBuilder.Entity<Flat>()
                .HasMany(f => f.Tenants)
                .WithOne(i => i.Flat)
                .HasForeignKey(t => t.FlatId);
        }

    }
}