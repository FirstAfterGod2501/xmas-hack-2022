namespace XMASCore;

public class Swarm
{
    public Drone[] Drones { get; protected set; }
    public int DroneCount { get; private set; }
    public Master Master { get; set; }
    public Drone[] Slaves { get; protected set; }
    public int SlaveCount { get; private set; }

    public Swarm(int lenght)
    {
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
            Master = new Master(drone);
        }
        else
        {
            Slaves[SlaveCount] = drone;
            ++SlaveCount;
        }
        Drones[DroneCount] = drone;
        ++DroneCount;
    }
}