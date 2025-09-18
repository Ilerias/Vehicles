using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vehicles;

public class Manager : IManager
{
    public List<Vehicle> Vehicles { get; set; }

    public int VehicleCount { get { return Vehicles.Count; } }

    public Manager()
    {
        Vehicles = new List<Vehicle>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        Vehicles.Add(vehicle);
    }

    public void Load(string cars, string trucks)
    {
        var carsText = File.ReadAllText(cars);
        var trucksText = File.ReadAllText(trucks);
        
        Vehicles.AddRange(JsonSerializer.Deserialize<List<Car>>(carsText));
        Vehicles.AddRange(JsonSerializer.Deserialize<List<Truck>>(trucksText));

        if (Vehicles.Count == 0)
        {
            throw new Exception("Üres jármű lista");
        }
        
        Console.WriteLine("Járművek sikeresen betöltve");
    }

    public List<Vehicle> GetTestDrive()
    {
        List<Vehicle> result = new List<Vehicle>();
        foreach (var v in Vehicles)
        {
            if (v.CanTestDrive)
            {
                result.Add(v);
            }
        }

        if (!result.Any())
        {
            throw new CustomException();
        }
        return result;
    }

    public Vehicle GetMaxTorqueHorsePowerRate()
    {
        if (!Vehicles.Any())
        {
            throw new CustomException();
        }

        Vehicle result = Vehicles[0];
        foreach (var v in Vehicles)
        {
            if (result.TorqueHorsePowerRate < v.TorqueHorsePowerRate)
            {
                result = v;
            }
        }
        return result;
    }

    public Vehicle GetMaxTorqueHorsePowerRateToDeliver()
    {
        Console.Write("Adja meg a rakomány méretét: ");
        var cargo = int.Parse(Console.ReadLine() ?? string.Empty);
        var possibleTrucks = new List<Truck>();
        var trucks = Vehicles.OfType<Truck>().ToList();

        foreach (var truck in trucks)
        {
            if (truck.PayloadCapacity >= cargo)
            {
                possibleTrucks.Add(truck);
            }
        }

        if (!possibleTrucks.Any())
        {
            throw new CustomException();
        }

        var strongestPossibleTruck = possibleTrucks[0];
        foreach (var truck in possibleTrucks)
        {
            if (truck.Torque > strongestPossibleTruck.Torque)
            {
                strongestPossibleTruck = truck;
            }
        }
        return strongestPossibleTruck;
    }

    public void CreateFuelStatistic()
    {
        var stats = new List<FuelStat>();
        var cars = Vehicles.OfType<Car>().ToList();

        foreach (FuelType fuelType in Enum.GetValues(typeof(FuelType)))
        {
            var count = 0;
            foreach (var car in cars)
            {
                if (car.Fuel == fuelType)
                {
                    count++;
                }
            }
            stats.Add(new FuelStat() {FuelName = fuelType.ToString(), Percentage = (int)((double)count / cars.Count * 100) });
        }
        
        File.WriteAllText("fuel_stats.json", JsonSerializer.Serialize(stats));
    }

}
