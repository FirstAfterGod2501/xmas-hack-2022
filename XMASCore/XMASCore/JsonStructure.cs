using Newtonsoft.Json;

namespace XMASCore;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Base
{
    [JsonProperty("x")]
    public int X { get; set; }

    [JsonProperty("y")]
    public int Y { get; set; }
}

public class DataTransferSystem
{
    [JsonProperty("range")]
    public int Range { get; set; }

    [JsonProperty("throughput")]
    public int Throughput { get; set; }

    [JsonProperty("linearScaleFactor")]
    public double LinearScaleFactor { get; set; }
}

public class DroneData
{
    [JsonProperty("totalBatterySize")]
    public int TotalBatterySize { get; set; }

    [JsonProperty("currentBatterySize")]
    public int CurrentBatterySize { get; set; }

    [JsonProperty("horizontalSpeed")]
    public int HorizontalSpeed { get; set; }

    [JsonProperty("takeoffSpeed")]
    public int TakeoffSpeed { get; set; }

    [JsonProperty("landingSpeed")]
    public int LandingSpeed { get; set; }

    [JsonProperty("weight")]
    public int Weight { get; set; }

    [JsonProperty("diameter")]
    public int Diameter { get; set; }

    [JsonProperty("payload")]
    public string Payload { get; set; }
}

public class Root
{
    [JsonProperty("Base")]
    public Base Base { get; set; }

    [JsonProperty("ServiceStation")]
    public ServiceStation ServiceStation { get; set; }

    [JsonProperty("dataTransferSystem")]
    public DataTransferSystem DataTransferSystem { get; set; }

    [JsonProperty("drones")]
    public List<DroneData> Drones { get; set; }
}

public class ServiceStation
{
    [JsonProperty("x")]
    public int X { get; set; }

    [JsonProperty("y")]
    public int Y { get; set; }
}

