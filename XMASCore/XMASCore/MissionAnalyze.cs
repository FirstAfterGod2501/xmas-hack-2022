using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;
using Image = SixLabors.ImageSharp.Image;

namespace XMASCore;

public class MissionAnalyze
{
    public static List<Point> FindPoints(string file, int width, int height)
    {
        var result = new List<Point>();
        var img = new Image<Rgba32>(width, height);
        img = Image.Load<Rgba32>(file);
        img.Mutate(x => x.Resize(width, height));
        
        for (int i = 0; i < img.Width; i+=4)
        {
            for (int j = 0; j < img.Height; j+=4)
            {
                var pixel = img[i, j];

                if (pixel.A>240)
                {
                    result.Add(new Point(i, j));
                }
            }
        }
        return result;
    }

    public static string[] GetImgs(MissionHandler missionHandler)
    {
        var res = new string[missionHandler.Missions.Count];
        int i = 0;
        foreach (var mission in missionHandler.Missions)
        {
            res[i] = mission.Img;
            i++;
        }

        return res;
    }

    public static void SetMissionPoints(MissionHandler missionHandler, int width, int height)
    {
        foreach (var mission in missionHandler.Missions)
        {
            mission.Points = FindPoints(mission.Img, width, height);
        }
    }
}