using APBDEX06.DTOs;
using APBDEX06.Repos;

namespace APBDEX06.Services
{
    public class PatientService
    {
        private readonly PatientRepo _repo;

        public PatientService(PatientRepo repo) { _repo = repo; }

        public async Task<PatientDTO> GetPatientWithDetailsAsync(int idPatient)
        {
            return await _repo.GetPatientWithDetailsAsync(idPatient);
        }
    }
}
