using APBDEX06.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace APBDEX06.EfConfigurations
{
    public class PrescriptionEfConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.ToTable("Prescription");

            builder.HasKey(e => e.IdPrescription);
            builder.Property(e => e.IdPrescription).ValueGeneratedOnAdd();

            builder.Property(e => e.Date).IsRequired().HasColumnType("date");
            builder.Property(e => e.DueDate).IsRequired().HasColumnType("date");
            builder.HasOne(e => e.Patient)
                .WithMany(m => m.Prescriptions)
                .HasForeignKey(m => m.IdPatient)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Doctor)
                .WithMany(m => m.Prescriptions)
                .HasForeignKey(m => m.IdDoctor)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
