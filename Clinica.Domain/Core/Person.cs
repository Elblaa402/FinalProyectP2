namespace Clinica.Domain.Core
{
    public abstract class Person : BaseEntity
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? Email { get; set; }
    }
}
