using APBDEX06.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace APBDEX06.EfConfigurations
{
    public class PrescriptionMedicamentEfConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder.ToTable("PerscriptionMedicament");

            builder.HasKey(e => new { e.IdPrescription, e.IdMedicament });

            builder.Property(e => e.Details).IsRequired().HasMaxLength(100);

            builder.HasOne(e => e.Prescription)
                .WithMany(m => m.PrescriptionMedicaments)
                .HasForeignKey(m => m.IdPrescription)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Medicament)
                .WithMany(m => m.PrescriptionMedicaments)
                .HasForeignKey(m => m.IdMedicament)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
