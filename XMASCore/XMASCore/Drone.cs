using System.Runtime.CompilerServices;

namespace XMASCore;

public class Drone
{
    public int Speed { get; protected set; }

    public int Id { get; protected set; }
    public Direction Direction { get; set; }
    public Point Position { get; protected set; }
    public int CommunicationRange { get; set; }
    
    public int Diameter { get; protected set; }

    public Drone(Point startPosition, int speed, int communicationRange)
    {
        Position = startPosition;
        Speed = speed;
        CommunicationRange = communicationRange;
        Direction = new Direction(0, 0);
    }

    public void UpdateHandler(Update update)
    {
        if (update.id == Id)
        {
            //do
        }
        else{
            if (update.jumpCount != update.maxJumpCounts)
            {
                update.jumpCount++;
                List<Drone> drones = DataTransmissionSystem.GetDronesInRange(this, 200);
                foreach (var drone in drones)
                {
                    drone.UpdateHandler(update);
                }
            }
        }
    }

    protected Drone(Drone drone)
    {
        Position = drone.Position;
        Speed = drone.Speed;
        CommunicationRange = drone.CommunicationRange;
        Direction = new Direction(0, 0);
    }


    public void Move()
    {
        DataTransmissionSystem.UpdateInformationAboutDrone(this);
        Position = new Point(Position.X + Direction.DeltaX * Speed, Position.Y + Direction.DeltaY * Speed);
        Direction = new Direction(0, 0);
    }

    
}

public class Master : Drone
{
    public Master(Drone drone) : base(drone:drone)
    {
        
    }
}