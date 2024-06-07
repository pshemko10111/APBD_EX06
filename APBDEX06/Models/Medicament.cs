using System;
using System.Collections.Generic;

namespace APBDEX06.Models;

public class Medicament
{
    public int IdMedicament { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}
