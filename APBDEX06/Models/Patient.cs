﻿using System;
using System.Collections.Generic;

namespace APBDEX06.Models;

public class Patient
{
    public int IdPatient { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly Birthdate { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; set; }
}
