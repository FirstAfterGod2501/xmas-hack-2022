using System.Collections;
using System.Data.SqlTypes;


namespace XMASCore;

public class DataTransmissionSystem
{
    public static int Range { get; set; }

    private static List<Update> Updates;

    private static List<Drone> Drones;

    public static List<Drone> GetDronesInRange(Drone drone, int range)
    {
        return new List<Drone>(Drones.Where(x => CalculatTool.PointDistance(x.Position, drone.Position) < Range));
    }

    public static void Registration(Drone drone)
    {
        Drones.Add(drone);
    }
    
    public static void UpdateInformationAboutDrone(Drone drone)
    {
        Drones.Remove(Drones.FirstOrDefault(x=>x.Id == drone.Id));
        Drones.Add(drone);
    }
    
    public static void SetDataTransmissionSystem(int range, int throughput, double linearThroughputDegradationFactor)
    {
        Drones = new();
        Range = range;
        throughput = throughput;
        linearThroughputDegradationFactor = linearThroughputDegradationFactor;
    }
}