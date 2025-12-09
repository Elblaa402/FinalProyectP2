using Clinica.Domain.Core;
using System.Collections.Generic;

namespace Clinica.Domain.Entities
{
    public class Paciente : Person
    {
        public DateTime FechaNacimiento { get; set; }
        public string? Direccion { get; set; }
        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
        public HistorialMedico? HistorialMedico { get; set; }
    }
}
