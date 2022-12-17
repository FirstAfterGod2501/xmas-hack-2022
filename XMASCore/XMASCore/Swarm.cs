namespace XMASCore;

public class Swarm
{
    public Drone[] Drones { get; }
    public int DroneCount { get; private set; }
    public Master Master { get; set; }
    public Drone[] Slaves { get; }
    public int SlaveCount { get; private set; }
    
    public Point Base { get; protected set; }
    public Point ServiceStation { get; protected set; }

    public Swarm(int lenght, Point @base, Point serviceStation)
    {
        Base = @base;
        ServiceStation = serviceStation;
        Drones = new Drone[lenght];
        Slaves = new Drone[lenght-1];
        DroneCount = 0;
    }

    public void AddDrone(Drone drone)
    {
        if (Drones.Length == DroneCount)
        {
            throw new ArgumentOutOfRangeException();
        }
        if (Master == null)
        {
            Master = new Master(drone,drone.Id);
            Drones[DroneCount] = Master;
            Drones[DroneCount].Id = DroneCount;
            ++DroneCount;
        }
        else
        {
            Slaves[SlaveCount] = drone;
            ++SlaveCount;
            Drones[DroneCount] = drone;
            ++DroneCount;
        }
        
    }
}