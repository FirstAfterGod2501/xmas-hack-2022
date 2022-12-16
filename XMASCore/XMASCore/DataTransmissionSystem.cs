using System.Collections;
using System.Data.SqlTypes;


namespace XMASCore;

public class DataTransmissionSystem
{
    public int Range { get; }

    private List<Update> Updates;

    private static List<Drone> Drones;

    public static List<Drone> GetDronesInRange(Drone drone, int range)
    {
        return new List<Drone>(Drones.Where(x => CalculatTool.PointDistance(x.Position, drone.Position) < range));
    }
    
    //миллиард коллов
    public static void UpdateInformationAboutDrone(Drone drone)
    {
        Drones.Remove(Drones.FirstOrDefault(x=>x.Id == drone.Id));
        Drones.Add(drone);
    }
    
    DataTransmissionSystem(int range)
    {
        Range = range;
    }
}