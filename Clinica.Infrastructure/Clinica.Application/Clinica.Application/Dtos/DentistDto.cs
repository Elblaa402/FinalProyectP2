namespace Clinica.Application.Dtos.Dentist
{
    public class DentistDto : DtoBase
    {
        public string Nombre { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
    }
}
