using APBDEX06.Context;
using APBDEX06.DTOs;
using Microsoft.EntityFrameworkCore;

namespace APBDEX06.Repos
{
    public class PatientRepo
    {
        private readonly ApbdContext _context;

        public PatientRepo(ApbdContext context)
        {
            _context = context;
        }

        public async Task<PatientDTO> GetPatientWithDetailsAsync(int idPatient)
        {
            var patient = await _context.Patients
                .Where(p => p.IdPatient == idPatient)
                .Include(pa => pa.Prescriptions)
                .ThenInclude(pb => pb.PrescriptionMedicaments)
                .ThenInclude(pc => pc.Medicament)
                .Include(pd => pd.Prescriptions)
                .ThenInclude(pe => pe.Doctor)
                .FirstOrDefaultAsync();

            if (patient == null) return null;

            var patientDTO = new PatientDTO
            {
                IdPatient = patient.IdPatient,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Prescriptions = patient.Prescriptions
                    .OrderBy(pf => pf.DueDate)
                    .Select(pg => new PrescriptionDTO
                    {
                        IdPrescription = pg.IdPrescription,
                        Date = pg.Date,
                        DueDate = pg.DueDate,
                        Doctor = new DoctorDTO
                        {
                            IdDoctor = pg.Doctor.IdDoctor,
                            FirstName = pg.Doctor.FirstName
                        },
                        Medicaments = pg.PrescriptionMedicaments
                            .Select(pm => new MedicamentDTO
                            {
                                IdMedicament = pm.IdMedicament,
                                Name = pm.Medicament.Name,
                                Dose = pm.Dose,
                                Description = pm.Details
                            }).ToList()
                    }).ToList()
            };

            return patientDTO;
        }


    }
}
