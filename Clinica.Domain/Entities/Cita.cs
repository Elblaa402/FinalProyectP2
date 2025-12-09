namespace Clinica.Domain.Entities
{
    public class Cita : Clinica.Domain.Core.BaseEntity
    {
        public DateTime FechaHora { get; set; }
        public string Motivo { get; set; } = null!;
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; } = null!;
        public int OdontologoId { get; set; }
        public Odontologo Odontologo { get; set; } = null!;
        public string? Observaciones { get; set; }
    }
}
