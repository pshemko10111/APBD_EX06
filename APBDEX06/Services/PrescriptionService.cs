using APBDEX06.Context;
using APBDEX06.DTOs;
using APBDEX06.Models;
using Microsoft.EntityFrameworkCore;

namespace APBDEX06.Services
{
    public class PrescriptionService
    {
        private readonly ApbdContext _context;

        public PrescriptionService(ApbdContext context) { _context = context; }

        public async Task AddNewPrescriptionAsync(NewPrescriptionRequestDTO request)
        {
            if (request.DueDate < request.Date) throw new ArgumentException("DueDate cannot be lower than Date");
            if (request.Medicaments.Count > 10) throw new ArgumentException("Max 10 meds per prescription");

            var patient = await _context.Patients
                .FirstOrDefaultAsync(p => p.IdPatient == request.Patient.IdPatient);

            if (patient == null) 
            {
                patient = new Patient
                {
                    FirstName = request.Patient.FirstName,
                    LastName = request.Patient.LastName,
                    Birthdate = request.Patient.Birthdate
                };

                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();
            }

            var prescription = new Prescription
            {
                Date = request.Date,
                DueDate = request.DueDate,
                IdPatient = request.Patient.IdPatient,
                IdDoctor = request.Patient.IdDoctor
            };

            foreach (var med in request.Medicaments) {
                var medicament = await _context.Medicaments
                    .FirstOrDefaultAsync(m => m.IdMedicament == med.IdMedicament);

                if (med == null) throw new NullReferenceException($"Med with ID {med.IdMedicament} does not exist");

                var presMeds = new PrescriptionMedicament
                {
                    IdMedicament = med.IdMedicament,
                    Medicament = medicament,
                    Dose = med.Dose,
                    Details = med.Description
                };
                prescription.PrescriptionMedicaments.Add(presMeds);
            }

            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();
        }
    }
}
