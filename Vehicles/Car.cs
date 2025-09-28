namespace Vehicles;

public enum FuelType
{
    Petrol,
    Diesel,
    Gas,
    Electricity
}
public class Car : Vehicle
{
    public FuelType Fuel { get; set; }
    public int Year { get; set; }

    public Car() { }

    public override bool CanDeliver(int cargoSize)
    {
        return false;
    }

    public bool IsOldTimer => DateTime.Now.Year - Year >= 20;
    
}


