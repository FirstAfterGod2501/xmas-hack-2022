namespace XMASCore;

class Program
{
    public static Swarm swarm;
    static void Main()
    {
        var data = InputJson.Read();
        data.Drones[0].Move();
        swarm = new Swarm(5);
        for (int i = 0; i < 2; i++)
        {
            swarm.AddDrone(new Drone(new Point(0,1),1, 100));
        }
        new Thread(() => Drawing.Start(swarm, 300, 300)).Start();
        Operator @operator = new Operator(new Point(0, 0),swarm);
        Thread.Sleep(1000);
        @operator.MoveSwarmToPoint(new Point(160, 50));
    }
}
