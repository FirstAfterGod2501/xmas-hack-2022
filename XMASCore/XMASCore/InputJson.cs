using Newtonsoft.Json;

namespace XMASCore;

public class InputJson
{
    public static InputData Read()
    {
        string fileText;
        using (StreamReader reader = new StreamReader("input.json"))
        {
            fileText = reader.ReadToEnd();
            Console.WriteLine(fileText);
        }
        return JsonConvert.DeserializeObject<InputData>(fileText);

    }
}