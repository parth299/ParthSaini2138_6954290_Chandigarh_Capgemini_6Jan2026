using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("1. Bank Management System");
        SavingsAccount savings = new SavingsAccount(101, "Rahul", 10000);
        savings.Deposit(2000);
        savings.AddInterest();
        savings.Display();
        CheckingAccount checking = new CheckingAccount(102, "Anita", 5000);
        checking.Withdraw(1000);
        checking.Display();
        Console.WriteLine("\n--------------------------------------\n");

        
        
        Console.WriteLine("2. University Enrollment System");
        Student student = new Student
        {
            Id = 1,
            Name = "Amit"
        };
        student.Courses.Add("C# Programming");
        student.Courses.Add("Data Structures");
        Professor professor = new Professor
        {
            Id = 101,
            Name = "Dr. Sharma",
            Subject = "Computer Science"
        };
        Course course = new Course
        {
            CourseName = "C# Programming",
            AssignedProfessor = professor
        };
        Console.WriteLine($"Student Name: {student.Name}");
        Console.WriteLine($"Course: {course.CourseName}");
        Console.WriteLine($"Professor: {course.AssignedProfessor.Name}");
        Console.WriteLine("\n--------------------------------------\n");

       
       
        Console.WriteLine("3. Vehicle Rental System");
        Car car = new Car
        {
            Model = "Honda City",
            RatePerDay = 1500
        };

        Customer rentalCustomer = new Customer
        {
            Name = "Suresh"
        };
        RentalTransaction rental = new RentalTransaction
        {
            Vehicle = car,
            Customer = rentalCustomer,
            Days = 3
        };
        rental.ShowBill();
        Console.WriteLine("\n--------------------------------------\n");


        Console.WriteLine("4. E-Commerce Product Catalog");
        EcommerceCustomer ecommerceCustomer = new EcommerceCustomer
        {
            Name = "Neha"
        };
        Electronics laptop = new Electronics
        {
            Id = 1,
            Name = "Laptop",
            Price = 55000
        };
        Books book = new Books
        {
            Id = 2,
            Name = "C# Programming Book",
            Price = 800
        };
        Cart cart = new Cart();
        cart.AddProduct(laptop);
        cart.AddProduct(book);
        Console.WriteLine($"Customer: {ecommerceCustomer.Name}");
        Console.WriteLine($"Cart Total: {cart.Total()}");
        Console.WriteLine("\n--------------------------------------\n");

       
       
        Console.WriteLine("5. Hospital Management System");
        Patient patient = new Patient
        {
            Id = 1,
            Name = "Ramesh"
        };
        patient.MedicalHistory.Add("Diabetes");
        Doctor doctor = new Doctor
        {
            Id = 201,
            Name = "Dr. Mehta",
            Specialization = "Cardiology"
        };
        Appointment appointment = new Appointment
        {
            Patient = patient,
            Doctor = doctor,
            Date = DateTime.Now
        };
        Console.WriteLine($"Patient: {appointment.Patient.Name}");
        Console.WriteLine($"Doctor: {appointment.Doctor.Name}");
        Console.WriteLine($"Specialization: {doctor.Specialization}");
        Console.WriteLine($"Appointment Date: {appointment.Date}");
        Console.WriteLine("\n--------------------------------------\n");
        Console.ReadLine();
    }
}
