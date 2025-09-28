namespace Vehicles;

public interface IManager
{
    int VehicleCount { get; }
    
    void AddVehicle(Vehicle vehicle);
    
    void Load (string cars, string trucks);

    List<Vehicle> GetTestDrive();
    
    Vehicle GetMaxTorqueHorsePowerRate();
    
    Vehicle GetMaxTorqueHorsePowerRateToDeliver();
    
    void CreateFuelStatistic();

    void InitializeLinkedList();

    void PrintVehicles();

    void PrintOldTimers();
    
    void SortOldTimers();
}