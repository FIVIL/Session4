using Microsoft.EntityFrameworkCore;
using Session4.Models.SimpleModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Session4.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Proffoser> Proffosers { get; set; }
        public DbSet<ProffessorFaculty> ProffessorFaculties { get; set; }

        public DbSet<First> Firsts { get; set; }
        public DbSet<Seccond> Secconds { get; set; }
        public DbSet<Third> Thirds { get; set; }
        public DbSet<Fourth> Fourths { get; set; }
        public DbSet<Fifth> Fifths { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>(e =>
            {
                e.HasIndex(p => new { p.StudentNumber, p.PersonalID }).IsUnique();
            });
            modelBuilder.Entity<Proffoser>(e =>
            {
                e.HasIndex(p => p.ShomarePersoneli).IsUnique();
            });
            modelBuilder.Entity<ProffessorFaculty>(e =>
            {
                e.HasKey(p => new { p.ProffoserID, p.FacultyID });
            });

            modelBuilder.Entity<Fifth>(e =>
            {
                e.HasKey(p => new { p.FirstID, p.FourthID });
            });
        }
    }
}
