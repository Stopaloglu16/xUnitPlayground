using CoreDomain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Reflection;

namespace Infrasture.Repo
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseInMemoryDatabase(databaseName: "AuthorDb");
        //}
        //public ApplicationDbContext()
        //{
        //}


        public DbSet<Address> Addresses { get; set; }
        public DbSet<Person> Persons => Set<Person>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Address>()
                .HasOne(p => p.PersonAddress)
                . WithMany(pp => pp.AddressList);

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}