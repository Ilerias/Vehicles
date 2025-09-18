namespace Vehicles;

public class Truck : Vehicle
{
    public int PayloadCapacity { get; set; }
    public int NumberOfAxles { get; set; }
    
    public Truck() { }

    public override bool CanDeliver(int cargoSize)
    {
        return cargoSize <= PayloadCapacity;
    }
}
