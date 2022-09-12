using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgramingLanguage> ProgramingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramingLanguage>(a =>
            {
                a.ToTable("ProgramingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.Technologies);
            });

            modelBuilder.Entity<Technology>(a =>
            {
                a.ToTable("Technologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.ProgramingLanguageId).HasColumnName("ProgramingLanguageId");
                a.HasOne(p => p.ProgramingLanguage);
            });


            ProgramingLanguage[] programingLanguagesEntitySeeds = { new(1, "C#"), new(2, "Java"), new(3, "JavaScript") };
            modelBuilder.Entity<ProgramingLanguage>().HasData(programingLanguagesEntitySeeds);

            Technology[] technologiesEntitySeeds = { new(1, 1, ".Net Core"), new(2, 1, ".Net Framework"), new(3, 2, "Spring"), new(4, 3, "AngularJS") };
            modelBuilder.Entity<Technology>().HasData(technologiesEntitySeeds);

        }
    }
}
