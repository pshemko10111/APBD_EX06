﻿using System;
using System.Collections.Generic;

namespace APBDEX06.Models;

public class PrescriptionMedicament
{
    public int IdMedicament { get; set; }
    public Medicament Medicament { get; set; }
    
    public int IdPrescription { get; set; }
    public Prescription Prescription { get; set; }
    public int Dose { get; set; }

    public string Details { get; set; }

}
