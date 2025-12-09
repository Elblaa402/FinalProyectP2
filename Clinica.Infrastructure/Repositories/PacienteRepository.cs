using Clinica.Domain.Entities;
using Clinica.Domain.Repository;
using Clinica.Infrastructure.Context;
using Clinica.Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
public class PacienteRepository
    : BaseRepository<Paciente>, IPacienteRepository
{
    private readonly ClinicaContext _clinicaContext;

    public PacienteRepository(ClinicaContext context)
        : base(context)
    {
        _clinicaContext = context;
    }

    public override async Task<IEnumerable<Paciente>> GetAllAsync()
    {
        return await _clinicaContext.Pacientes
            .Include(p => p.HistorialMedico)
            .AsNoTracking()
            .ToListAsync();
    }

    public override async Task<Paciente?> GetByIdAsync(int id)
    {
        return await _clinicaContext.Pacientes
            .Include(p => p.Citas)
            .Include(p => p.HistorialMedico)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task DeleteAsync(Paciente paciente)
    {
        _clinicaContext.Pacientes.Remove(paciente);
        await _clinicaContext.SaveChangesAsync();
    }

    // Extra opcional
    public async Task DeleteByIdAsync(int id)
    {
        var entity = await _clinicaContext.Pacientes.FindAsync(id);
        if (entity != null)
            await DeleteAsync(entity);
    }
}

