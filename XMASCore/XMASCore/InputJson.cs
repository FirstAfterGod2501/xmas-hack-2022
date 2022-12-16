using Newtonsoft.Json;

namespace XMASCore;

public class InputJson
{
    public static Root Read()
    {
        string fileText;
        using (StreamReader reader = new StreamReader("Config/config.json"))
        {
            fileText = reader.ReadToEnd();
        }
        return JsonConvert.DeserializeObject<Root>(fileText);

    }
}