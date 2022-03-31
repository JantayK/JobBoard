using System;
using System.Collections.Generic;
using System.Text;
using HeadHunter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HeadHunter
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set;  }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasIndex(x => x.Login)
                .IsUnique();

        }
    }
}
