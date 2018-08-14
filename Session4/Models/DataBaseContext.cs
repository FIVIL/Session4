using Microsoft.EntityFrameworkCore;
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
        }
    }
}
