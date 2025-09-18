using System.Text.Json;

namespace Vehicles;

class Program
{
    static void Main(string[] args)
    {
        Manager manager = new Manager();

        try
        {
            manager.Load("cars.json", "trucks.json");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Nem megfelelő json formátum: {ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Nem megfelelő formátum: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hiba történt: {ex.Message}");
        }
        finally
        {
            if (manager.VehicleCount == 0)
            {
                var car = new Car()
                {
                    Name = "Fusion",
                    Brand = "Ford",
                    Year = 2005,
                    Price = 900000,
                    HorsePower = 80,
                    Torque = 86,
                    Fuel = FuelType.Petrol,
                    LicensePlateNumber = "SRV621",
                    Color = "Grey"
                };
                manager.AddVehicle(car);
            }
        }

        try
        {
            var testDriveVehicle = manager.GetTestDrive();
            Console.WriteLine("A tesztre elvihető járművek");
            foreach (var v in testDriveVehicle)
            {
                Console.WriteLine(v);
            }
        }
        catch (CustomException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            var maxTorqueHorsePowerRateVehicle = manager.GetMaxTorqueHorsePowerRate();
            Console.WriteLine($"A legnagyobb nyomaték/lóerő aránnyal rendelkező jármű: {maxTorqueHorsePowerRateVehicle}");
        }
        catch (CustomException ex)
        {
            Console.WriteLine(ex);
        }

        try
        {
            var maxTorqueHorsePowerRateVehicleToDeliver = manager.GetMaxTorqueHorsePowerRateToDeliver();
            Console.WriteLine($"A legnagyobb nyomatékkal rendelkező jármű amely képes elszállítani a rakományt:  {maxTorqueHorsePowerRateVehicleToDeliver}");
        }
        catch (CustomException ex)
        {
            Console.WriteLine(ex);
        }
        
        manager.CreateFuelStatistic();
    }
}