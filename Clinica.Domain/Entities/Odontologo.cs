using Clinica.Domain.Core;
using System.Collections.Generic;

namespace Clinica.Domain.Entities
{
    public class Odontologo : Person
    {
        public string Especialidad { get; set; } = null!;
        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
    }
}
