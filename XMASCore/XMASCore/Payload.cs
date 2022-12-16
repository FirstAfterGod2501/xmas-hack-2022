namespace XMASCore;

public enum PayloadDirection
{
    Fixed, Hemisphere
}

public enum PayloadScope
{
    Cylinder, Hemisphere, Pyramid, Cone
}

public enum ActivationType
{
    OneTime, ContinuousOverTerritory, Continuous, PeriodicOverTerritory
}

public enum Purpose
{
    Seeding, Scanning3D, Mapping, Detection, Recognition, Chasing, Delivery, ScanningUnderground
}

public abstract class Payload
{
    public int Weight { get; protected set; }
    public int BatteryConsumption { get; protected set; }
    public int MaxDistance { get; protected set; }
    public int Radius { get; protected set; }
    public PayloadDirection Direction { get; protected set; }
    public ActivationType ActivationType { get; protected set; }
    public Purpose[] Purpose;
    public PayloadScope Scope { get; protected set; }
}

public class Lidar : Payload
{
    public Lidar(int radius)
    {
        Direction = PayloadDirection.Fixed;
        ActivationType = ActivationType.ContinuousOverTerritory;
        Purpose = new Purpose[] { XMASCore.Purpose.Scanning3D };
        Weight = 2;
        BatteryConsumption = 2;
        Scope = PayloadScope.Cone;
        MaxDistance = 200;
        Radius = radius;
    }
}