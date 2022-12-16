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

    public int c = 0;

    private List<int> Hashes = new List<int>();

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
        if (update.Id == Id)
        {
            switch (update.Action)
            {
                case Action.move:
                    MoveDrone(new Point(update.X,update.Y),update.FromId);
                    break;
                case Action.stay:
                    MoveDrone(new Point(update.X,update.Y),update.FromId);
                    break;
                case Action.work:
                    break;
                case Action.returnInbase:
                    break;
                case Action.sayCoordsResponse:
                    break;
                case Action.sayCoords:
                    foreach (var drone in DataTransmissionSystem.GetDronesInRange(this,DataTransmissionSystem.Range))        
                    {
                        drone.UpdateHandler(new Update(Id,update.FromId,Action.sayCoordsResponse,1,Position.X,Position.Y));
                    }
                    break;
                case Action.isDestinationReached:
                    if (!Hashes.Contains(update.HashCode.GetHashCode()))
                    {
                        Console.WriteLine("id: " + update.FromId);
                        Hashes.Add(update.HashCode.GetHashCode());
                    }

                    break;
            }
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

    protected Drone(Drone drone,int id)
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
        Id = id;
        Direction = new Direction(0, 0);
        DataTransmissionSystem.Registration(this);
    }

    public Drone(Point position, DroneData droneData,int id)
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
        Id = id;
        DataTransmissionSystem.Registration(this);
    }

    private void MoveDrone(Point point,int mastersId)
    {
        while (!Position.Equals(point))
        {
            Direction = CalculatTool.FineDestDirection(this, point,
                DataTransmissionSystem.GetDronesInRange(this, DataTransmissionSystem.Range));
            Move();
            Thread.Sleep(50);
        }

        foreach (var drone in DataTransmissionSystem.GetDronesInRange(this,DataTransmissionSystem.Range))
        {
            drone.UpdateHandler(new Update(Id,mastersId,Action.isDestinationReached,1,Position.X,Position.Y));
        }
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
    public Master(Drone drone,int id) : base(drone:drone,id:id)
    {
        
    }

    public void moveDude(int dudeId,Point point)
    {
        foreach (var drones in DataTransmissionSystem.GetDronesInRange(this,DataTransmissionSystem.Range))
        {
            drones.UpdateHandler(new Update(Id,dudeId,Action.move,100,point.X,point.Y));
        }
    }
}
