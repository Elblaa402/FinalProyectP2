namespace Clinica.Application.Dtos.Patient
{
    public class PatientDto : DtoBase
    {
        public string Nombre { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public int DentistId { get; set; }
    }
}

