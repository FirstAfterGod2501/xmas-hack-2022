namespace XMASCore;

public class Drone
{
    public int Speed { get; protected set; }
    public int Id { get; set; }
    public Direction Direction { get; set; }
    public Point Position { get; protected set; }
    public int TotalBatterySize { get; set; }
    public int CurrentBatterySize { get; set; }
    public int HorizontalSpeed { get; set; }
    public int TakeoffSpeed { get; set; }
    public int LandingSpeed { get; set; }
    public int Weight { get; set; }
    public int Diameter { get; set; }
    public Payload Payload { get; set; }
    public DataTransmissionSystem DataTransmissionSystem { get; protected set; }
    
    public Dictionary<string, Payload> Payloads = new Dictionary<string, Payload>()
    {
        { "Lidar", new Lidar(1) },
        { "Spraying", new Spraying(1) },
        { "HighDefinitionCamera", new HighDefinitionCamera(1) },
        { "CameraWithPayload", new CameraWithPayload(1) },
        { "LoadWeight", new LoadWeight(1, 5) },
        { "GroundPenetratingRadar", new GroundPenetratingRadar(1) },
        
    };

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
        Speed = drone.Speed;TotalBatterySize = drone.TotalBatterySize;
        CurrentBatterySize  = drone.CurrentBatterySize;
        HorizontalSpeed  = drone.HorizontalSpeed;
        TakeoffSpeed  = drone.TakeoffSpeed;
        LandingSpeed  = drone.LandingSpeed;
        Weight  = drone.Weight;
        Diameter  = drone.Diameter;
        Payload = drone.Payload;

        DataTransmissionSystem = new DataTransmissionSystem();
        Direction = new Direction(0, 0);
    }

    public Drone(Point position, DroneData droneData)
    {
        Position = position;
        TotalBatterySize = droneData.TotalBatterySize;
        CurrentBatterySize  = droneData.CurrentBatterySize;
        HorizontalSpeed  = droneData.HorizontalSpeed;
        TakeoffSpeed  = droneData.TakeoffSpeed;
        LandingSpeed  = droneData.LandingSpeed;
        Weight  = droneData.Weight;
        Diameter  = droneData.Diameter;
        Payload = Payloads[droneData.Payload];
        Speed = HorizontalSpeed;
        DataTransmissionSystem = new DataTransmissionSystem();
    }


    public void Move()
    {
       // DataTransmissionSystem.UpdateInformationAboutDrone(this);
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