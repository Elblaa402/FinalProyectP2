using Clinica.Domain.Entities;

namespace Clinica.Domain.Repository
{
    public interface IOdontologoRepository
    {
        Task<IEnumerable<Odontologo>> GetAllAsync();
        Task<Odontologo?> GetByIdAsync(int id);
        Task<Odontologo> AddAsync(Odontologo odontologo);
        Task UpdateAsync(Odontologo odontologo);
        Task DeleteAsync(int id);
    }
}
