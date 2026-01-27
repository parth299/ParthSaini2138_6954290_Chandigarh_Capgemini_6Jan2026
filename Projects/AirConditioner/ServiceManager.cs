class ServiceManager<T> where T : AirConditioner
{
    public void Service(T ac)
    {
        Console.WriteLine($"Servicing AC: {ac.BrandName}");
        ac.PowerOff();
        Console.WriteLine("Service completed.\n");
    }
}
