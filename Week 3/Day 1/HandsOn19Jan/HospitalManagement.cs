using System;
using System.Collections.Generic;

class HospitalPerson
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Patient : HospitalPerson
{
    public List<string> MedicalHistory = new List<string>();
}

class Doctor : HospitalPerson
{
    public string Specialization { get; set; }
}

class Nurse : HospitalPerson
{
    public string Shift { get; set; }
}

class Appointment
{
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    public DateTime Date { get; set; }
}

class MedicalRecord
{
    public Patient Patient { get; set; }
    public string Diagnosis { get; set; }
}
