using System;

class Vehicle
{
    public string Model { get; set; }
    public double RatePerDay { get; set; }

    public virtual double CalculateRent(int days)
    {
        return days * RatePerDay;
    }
}

class Car : Vehicle { }
class Bike : Vehicle { }
class Truck : Vehicle { }

class Customer
{
    public string Name { get; set; }
}

class RentalTransaction
{
    public Vehicle Vehicle { get; set; }
    public Customer Customer { get; set; }
    public int Days { get; set; }

    public void ShowBill()
    {
        Console.WriteLine($"Total Rent: {Vehicle.CalculateRent(Days)}");
    }
}
