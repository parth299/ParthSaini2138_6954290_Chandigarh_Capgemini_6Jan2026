using System;

class Program {
    public static void Main(string[] args) {
        AirConditioner voltas = new AirConditioner("voltas");

        voltas.ChangeMode("Dry");
        voltas.ChangeTemperature(30);

        voltas.CheckStatus();

        AirConditioner newVoltas = new AirConditioner(voltas);

        Console.WriteLine("\n");

        voltas.ChangeMode("Fan");

        try {
            voltas.ChangeTemperature(16);
        }
        catch(ArgumentOutOfRangeException ex) {
            Console.WriteLine(ex.Message);
        }

        voltas.CheckStatus();
        newVoltas.CheckStatus();

        SmartAirConditioner smartAC = new SmartAirConditioner("Daikin");
        smartAC.PowerOn();
        smartAC.ControlUsingMobileApp();

        SplitAirConditioner splitAC = new SplitAirConditioner("Samsung", 5);
        splitAC.PowerOn();
        splitAC.ChangeMode("Heating");
        splitAC.ShowEnergyRating();
    }
}
