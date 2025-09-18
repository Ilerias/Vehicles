namespace Vehicles;

public abstract class Vehicle
{
    public string Brand { get; set; } = "";
    public string Name { get; set; } = "";
    public string Color { get; set; } = "";
    public int HorsePower { get; set; }
    public int Torque { get; set; }
    public string LicensePlateNumber { get; set; } = "";
    public int Price { get; set; }

    public double TorqueHorsePowerRate => (double)Torque / HorsePower;

    public bool CanTestDrive => Price < 10000000;

    public abstract bool CanDeliver(int cargoSize);

    public override string ToString()
    {
        return $"Brand: {Brand}, Name: {Name}, License plate number: {LicensePlateNumber}";
    }
}