class Program {
    public static void Main(string[] args) {
        List<Patient> PatientList = new List<Patient>();
        PatientBO patientBo = new PatientBO();

        int noOfPatients;
        Console.WriteLine("Enter the number of patients");
        noOfPatients = int.Parse(Console.ReadLine());

        string _name; int age; string illness; string city;
        Patient patient = null;
        for(int i=0; i<noOfPatients; i++) {
            Console.WriteLine("Enter patient " + i+1 +" details:");
            Console.WriteLine("Enter the name");
            _name = Console.ReadLine();
            Console.WriteLine("Enter the age");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the illness");
            illness = Console.ReadLine();
            Console.WriteLine("Enter the city");
            city = Console.ReadLine();

            patient = new Patient(_name, age, illness, city);
            PatientList.Add(patient);
        }

        bool exit = false;
        while(!exit) {
            Console.WriteLine("Enter your choice");
            Console.WriteLine("1)Display Patient Details");
            Console.WriteLine("2)Display Youngest Patient Details");
            Console.WriteLine("3)Display Patients from City");
            string choice = Console.ReadLine();

            switch (choice) {
                case "1": 
                    Console.WriteLine("Enter patient name: ");
                    string nameToFind = Console.ReadLine();
                    patientBo.DisplayPatientDetails(PatientList, nameToFind);
                    break;
                case "2":
                    Console.WriteLine("The Youngest Person details are: ");
                    patientBo.DisplayYoungestPatientDetails(PatientList);
                    break;
                case "3":   
                    Console.WriteLine("Enter city name: ");
                    string cname = Console.ReadLine();
                    patientBo.displayPatientsFromCity(PatientList, cname);
                    break;
                default: 
                    Console.WriteLine("Do you want to continue(Yes / No)");
                    string yesorno = Console.ReadLine();
                    if(yesorno.ToLower() == "yes") {
                        continue;
                    }
                    else if(yesorno.ToLower() == "no") {
                        exit = true;
                    }
                    else {
                        Console.WriteLine("Invalid Character Entered");
                    }
                    break;
            }
        }
    }
}