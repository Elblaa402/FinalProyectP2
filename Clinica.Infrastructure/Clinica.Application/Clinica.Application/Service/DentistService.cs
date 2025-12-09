using Microsoft.EntityFrameworkCore;
using Clinica.Application.Contract;
using Clinica.Application.Core;
using Clinica.Application.Dtos.Dentist;
using Clinica.Application.Dtos.Patient;
using Clinica.Domain.Entities;
using Clinica.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Application.Service
{
    public class DentistService : BaseService, IDentistService
    {
        private readonly ClinicaContext _context;

        public DentistService(ClinicaContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult<DentistDto>> CreateAsync(DentistDto dto)
        {
            var entity = new Dentist
            {
                Nombre = dto.Nombre,
                Especialidad = dto.Especialidad,
                Telefono = dto.Telefono
            };

            _context.Dentists.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            return ServiceResult<DentistDto>.Ok(dto, "Odontólogo creado correctamente.");
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var entity = await _context.Dentists.FindAsync(id);
            if (entity == null) return ServiceResult<bool>.Fail("Odontólogo no encontrado.");

            _context.Dentists.Remove(entity);
            await _context.SaveChangesAsync();

            return ServiceResult<bool>.Ok(true, "Odontólogo eliminado.");
        }

        public async Task<ServiceResult<IEnumerable<DentistDto>>> GetAllAsync()
        {
            var list = await _context.Dentists
                .AsNoTracking()
                .Select(d => new DentistDto
                {
                    Id = d.Id,
                    Nombre = d.Nombre,
                    Especialidad = d.Especialidad,
                    Telefono = d.Telefono
                })
                .ToListAsync();

            return ServiceResult<IEnumerable<DentistDto>>.Ok(list);
        }

        public async Task<ServiceResult<DentistDto>> GetByIdAsync(int id)
        {
            var d = await _context.Dentists
                .Where(x => x.Id == id)
                .Select(x => new DentistDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Especialidad = x.Especialidad,
                    Telefono = x.Telefono
                })
                .FirstOrDefaultAsync();

            if (d == null)
                return ServiceResult<DentistDto>.Fail("Odontólogo no encontrado.");

            return ServiceResult<DentistDto>.Ok(d);
        }

        public async Task<ServiceResult<DentistDto>> UpdateAsync(int id, DentistDto dto)
        {
            var entity = await _context.Dentists.FindAsync(id);
            if (entity == null)
                return ServiceResult<DentistDto>.Fail("Odontólogo no encontrado.");

            entity.Nombre = dto.Nombre;
            entity.Especialidad = dto.Especialidad;
            entity.Telefono = dto.Telefono;

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            return ServiceResult<DentistDto>.Ok(dto, "Odontólogo actualizado correctamente.");
        }

        public async Task<ServiceResult<IEnumerable<PatientDto>>> GetPatientsByDentistAsync(int dentistId)
        {
            var pacientes = await _context.Patients
                .Where(p => p.DentistId == dentistId)
                .Select(p => new PatientDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Cedula = p.Cedula,
                    Telefono = p.Telefono,
                    DentistId = p.DentistId
                })
                .ToListAsync();

            return ServiceResult<IEnumerable<PatientDto>>.Ok(pacientes);
        }
    }
}
