namespace Clinica.Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public int DentistId { get; set; }
        public Dentist? Dentist { get; set; }
    }
}

