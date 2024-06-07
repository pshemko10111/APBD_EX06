namespace APBDEX06.DTOs
{
    public class PrescriptionDTO
    {
        public int IdPrescription { get; set; }
        public DateOnly Date { get; set; }
        public DateOnly DueDate { get; set; }
        public DoctorDTO Doctor { get; set; }
        public List<MedicamentDTO> Medicaments { get; set; }
    }
}
