namespace XMASCore;

class Program
{
    public static Swarm swarm;
    static void Main()
    {
        int width = 300;
        int height = 300;
        var data = InputJson.ReadDrone("Config/config.json");
        var missions = InputJson.ReadMissions("Config/Missions.json");
        var missionsImg = MissionAnalyze.GetImgs(missions);
        MissionAnalyze.SetMissionPoints(missions, width, height);
        DataTransmissionSystem.SetDataTransmissionSystem(data.DataTransferSystem.Range,data.DataTransferSystem.Throughput,data.DataTransferSystem.LinearScaleFactor);
        swarm = new Swarm(data.Drones.Count, new Point(data.Base.X, data.Base.Y), new Point(data.ServiceStation.X, data.ServiceStation.Y));
        for (int i = 0; i < data.Drones.Count; i++)
        {
            swarm.AddDrone(new Drone(new Point(0,1),data.Drones[i],i));
        }

        string[] imgs = new[] { "Fields/img.png",};
        Array.Resize(ref imgs, imgs.Length + missionsImg.Length);
        Array.Copy(missionsImg, 0, imgs, imgs.Length - missionsImg.Length, missionsImg.Length);
        
        new Thread(() => Drawing.Start(swarm, imgs, width, height)).Start();
        Operator @operator = new Operator(new Point(0, 0),swarm);
        Thread.Sleep(1000);
        @operator.SendMission(missions);
        //@operator.MoveSwarmToPoint(a[0]);
    }
}
