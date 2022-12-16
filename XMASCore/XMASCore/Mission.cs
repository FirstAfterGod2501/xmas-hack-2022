namespace XMASCore;
using Newtonsoft.Json;


public class Cargo
{
    [JsonProperty("weight")]
    public int Weight { get; set; }

    [JsonProperty("size")]
    public int Size { get; set; }
}

public class Mission
{
    [JsonProperty("evaluationPeriod")]
    public string EvaluationPeriod { get; set; }

    [JsonProperty("movementType")]
    public string MovementType { get; set; }

    [JsonProperty("missionContent")]
    public MissionContent MissionContent { get; set; }

    [JsonProperty("missionTime")]
    public int MissionTime { get; set; }

    [JsonProperty("cargo")]
    public Cargo Cargo { get; set; }

    [JsonProperty("period")]
    public int? Period { get; set; }
}

public class MissionContent
{
    [JsonProperty("coordinates")]
    public List<int> Coordinates { get; set; }

    [JsonProperty("seeding")]
    public bool Seeding { get; set; }

    [JsonProperty("delivery")]
    public bool Delivery { get; set; }

    [JsonProperty("scanning3D")]
    public bool Scanning3D { get; set; }

    [JsonProperty("scanningUnderground")]
    public bool ScanningUnderground { get; set; }

    [JsonProperty("mapping")]
    public bool Mapping { get; set; }

    [JsonProperty("detection")]
    public bool Detection { get; set; }

    [JsonProperty("recognition")]
    public bool Recognition { get; set; }

    [JsonProperty("chasing")]
    public bool Chasing { get; set; }
}

public class MissionHandler
{
    [JsonProperty("Missions")]
    public List<Mission> Missions { get; set; }
}
