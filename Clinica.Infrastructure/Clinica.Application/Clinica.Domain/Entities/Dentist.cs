namespace Clinica.Domain.Entities
{
    public class Dentist
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Especialidad { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public ICollection<Patient>? Patients { get; set; }
    }
}
