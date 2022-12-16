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
        return Drones.Where(x => CalculatTool.PointDistance(x.Position, drone.Position) < Range).ToList();
    }

    public static void Registration(Drone drone)
    {
        Drones.Add(drone);
    }
    
    public static void UpdateInformationAboutDrone(Drone drone)
    {
        var droneToDelete = Drones.FirstOrDefault(x => x.Id == drone.Id);
        if (droneToDelete != null)
        {
            try
            {
                Drones.Remove(droneToDelete);
            }
            catch (Exception ex)
            {
                //похуй
            }
        }

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