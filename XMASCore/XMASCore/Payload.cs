using System.Security.Cryptography.X509Certificates;

namespace XMASCore;

public enum PayloadDirection
{
    Fixed, 
    Hemisphere
}

public enum PayloadScope
{
    Cylinder, 
    Hemisphere, 
    Pyramid, 
    Cone
}

public enum ActivationType
{
    OneTime, 
    ContinuousOverTerritory, 
    Continuous, 
    PeriodicOverTerritory
}

public enum Purpose
{
    Seeding, 
    Scanning3D,
    Mapping,
    Detection,
    Recognition, 
    Chasing, 
    Delivery, 
    ScanningUnderground
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

public class Spraying : Payload
{
    public Spraying(int radius)
    {
        Direction = PayloadDirection.Fixed;
        ActivationType = ActivationType.ContinuousOverTerritory;
        Purpose = new Purpose[] { XMASCore.Purpose.Seeding };
        Weight = 2;
        BatteryConsumption = 50;
        Scope = PayloadScope.Cone;
        MaxDistance = 5;
        Radius = radius;
    }
}

public class HighDefinitionCamera : Payload
{
    public HighDefinitionCamera(int radius)
    {
        Direction = PayloadDirection.Fixed;
        ActivationType = ActivationType.ContinuousOverTerritory;
        Purpose = new Purpose[] { XMASCore.Purpose.Mapping, XMASCore.Purpose.Recognition };
        Weight = 1;
        BatteryConsumption = 50;
        Scope = PayloadScope.Pyramid;
        MaxDistance = 1000;
        Radius = radius;
    }
}

public class CameraWithPayload : Payload
{
    public CameraWithPayload(int radius)
    {
        Direction = PayloadDirection.Hemisphere;
        ActivationType = ActivationType.Continuous;
        Purpose = new Purpose[] 
        {
            XMASCore.Purpose.Chasing,
            XMASCore.Purpose.Detection,
            XMASCore.Purpose.Recognition
        };
        Weight = 2;
        BatteryConsumption = 10;
        Scope = PayloadScope.Hemisphere;
        MaxDistance = 400;
        Radius = radius;
    }
}

public class LoadWeight : Payload
{
    public LoadWeight(int radius, int weight)
    {
        Direction = PayloadDirection.Fixed;
        ActivationType = ActivationType.OneTime;
        Purpose = new Purpose[] { XMASCore.Purpose.Delivery };
        Weight = 2+weight;
        BatteryConsumption = 0;
        Scope = PayloadScope.Cylinder;
        MaxDistance = 1;
        Radius = radius;
    }
}

public class GroundPenetratingRadar : Payload
{
    public GroundPenetratingRadar(int radius)
    {
        Direction = PayloadDirection.Fixed;
        ActivationType = ActivationType.ContinuousOverTerritory;
        Purpose = new Purpose[] { XMASCore.Purpose.ScanningUnderground };
        Weight = 5;
        BatteryConsumption = 10;
        Scope = PayloadScope.Cylinder;
        MaxDistance = 15;
        Radius = radius;
    }
}
