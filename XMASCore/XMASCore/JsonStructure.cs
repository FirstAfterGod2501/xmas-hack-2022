using Newtonsoft.Json;

namespace XMASCore;

public class InputData
{
    [JsonProperty("Base")]
    public Base Base { get; set; }

    [JsonProperty("ServiceStation")]
    public Base ServiceStation { get; set; }

    [JsonProperty("Drones")]
    public Drone[] Drones { get; set; }
}

public class Base
{
    [JsonProperty("x")]
    public long X { get; set; }

    [JsonProperty("y")]
    public long Y { get; set; }
}

public class DroneData
{
    [JsonProperty("Payload")]
    public string Payload { get; set; }

    [JsonProperty("Speed")]
    public long Speed { get; set; }

    [JsonProperty("MaxBattary")]
    public long MaxBattary { get; set; }

    [JsonProperty("battery")]
    public long Battery { get; set; }

    [JsonProperty("Diameter")]
    public long Diameter { get; set; }

    [JsonProperty("resource")]
    public long Resource { get; set; }

    [JsonProperty("weight")]
    public long Weight { get; set; }
}