using Clinica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Clinica.Infrastructure
{
    public class ClinicaContext : DbContext
    {
        public ClinicaContext(DbContextOptions<ClinicaContext> options) : base(options) { }

        public DbSet<Dentist> Dentists { get; set; } = null!;
        public DbSet<Patient> Patients { get; set; } = null!;
        public object Pacientes { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dentist>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Nombre).IsRequired().HasMaxLength(120);
            });

            modelBuilder.Entity<Patient>(b =>
            {
                b.HasKey(x => x.Id);
                b.HasOne(x => x.Dentist)
                 .WithMany(d => d.Patients)
                 .HasForeignKey(x => x.DentistId);
            });
        }
    }
}
