namespace APBDEX06.DTOs
{
    public class NewPrescriptionRequestDTO
    {
        public PatientDTO Patient { get; set; }
        public List<MedicamentRequestDTO> Medicaments { get; set; }
        public DateOnly Date { get; set; }
        public DateOnly DueDate { get; set; }
    }
}
