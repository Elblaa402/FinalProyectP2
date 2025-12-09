namespace Clinica.Domain.Entities
{
    public class HistorialMedico : Clinica.Domain.Core.BaseEntity
    {
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; } = null!;
        public string Notas { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}
