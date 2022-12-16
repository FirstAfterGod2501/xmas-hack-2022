namespace XMASCore;

class Program
{
    public static Swarm swarm;
    static void Main()
    {
        DataTransmissionSystem.SetDataTransmissionSystem(200,0,0);
        var data = InputJson.Read();
        swarm = new Swarm(data.Drones.Count);
        for (int i = 0; i < data.Drones.Count; i++)
        {
            swarm.AddDrone(new Drone(new Point(0,1),data.Drones[i]));
        }

        string[] imgs = new[] { "Fields/img.png" };
        new Thread(() => Drawing.Start(swarm, imgs, 300, 300)).Start();
        Operator @operator = new Operator(new Point(0, 0),swarm);
        Thread.Sleep(1000);
        @operator.suka();
        @operator.MoveSwarmToPoint(new Point(160, 50));
    }
}
