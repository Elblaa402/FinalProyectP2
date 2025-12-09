using Clinica.Domain.Entities;

namespace Clinica.Domain.Repository
{
    public interface IHistorialMedicoRepository
    {
        Task<HistorialMedico?> GetByPacienteIdAsync(int pacienteId);
        Task<HistorialMedico> AddAsync(HistorialMedico historial);
        Task UpdateAsync(HistorialMedico historial);
    }
}
