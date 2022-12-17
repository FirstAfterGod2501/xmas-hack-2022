using Newtonsoft.Json;

namespace XMASCore;

public class InputJson
{
    public static Root ReadDrone(string file)
    {
        string fileText;
        using (StreamReader reader = new StreamReader(file))
        {
            fileText = reader.ReadToEnd();
        }
        return JsonConvert.DeserializeObject<Root>(fileText);
    }

    public static MissionHandler ReadMissions(string file)
    {
        string fileText;
        using (StreamReader reader = new StreamReader(file))
        {
            fileText = reader.ReadToEnd();
        }
        return JsonConvert.DeserializeObject<MissionHandler>(fileText);
    }
}