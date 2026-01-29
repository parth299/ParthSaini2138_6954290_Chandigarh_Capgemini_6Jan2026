class PatientBO {

    public void DisplayPatientDetails (List<Patient> patientList, string name) {
        List<Patient> matchingName = new List<Patient>();
        foreach(Patient patient in patientList) {
            if(patient.Name == name) {
                matchingName.Add(patient);
            }
        }

        if(matchingName.Count == 0) {
            Console.WriteLine("Patient named " + name + " not found");
        }
        else {
            foreach(Patient p in matchingName) {
                Console.WriteLine(p.ToString());
            }
        }
    }

    public void DisplayYoungestPatientDetails (List<Patient> patientList) {
        Patient youngestPatient = null;

        foreach(Patient p in patientList) {
            if(youngestPatient == null) {
                youngestPatient = p;
            }
            else if(youngestPatient.Age > p.Age) {
                youngestPatient = p;
            }
        }

        if(youngestPatient == null) {
            Console.WriteLine("Patient list is null");
            return ;
        }

        Console.WriteLine(youngestPatient.ToString());
    }

    public void displayPatientsFromCity (List<Patient> patientList, string cname) {
        List<Patient> matchingCity = new List<Patient>();
        foreach(Patient patient in patientList) {
            if(patient.City == cname) {
                matchingCity.Add(patient);
            }
        }

        if(matchingCity.Count == 0) {
            Console.WriteLine("City named " + cname + " not found");
        }
        else {
            foreach(Patient p in matchingCity) {
                p.ToString();
            }
        }
    }
 
}