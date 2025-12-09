using Microsoft.EntityFrameworkCore;
using Clinica.Domain.Entities;

namespace Clinica.Infrastructure.Context
{
    public class ClinicaContext : DbContext
    {
        public ClinicaContext(DbContextOptions<ClinicaContext> options)
            : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Odontologo> Odontologos { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<HistorialMedico> historialMedicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
