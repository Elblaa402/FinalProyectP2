using Clinica.Application.Core;
using Clinica.Application.Dtos.Dentist;
using Clinica.Application.Dtos.Patient;

namespace Clinica.Application.Contract
{
    public interface IDentistService : IBaseService<DentistDto>
    {
        Task<ServiceResult<IEnumerable<PatientDto>>> GetPatientsByDentistAsync(int dentistId);
    }
}
