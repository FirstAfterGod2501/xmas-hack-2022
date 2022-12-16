namespace XMASCore;

class Program
{
    public static Swarm swarm;
    static void Main()
    {
        swarm = new Swarm(5);
        for (int i = 0; i < 5; i++)
        {
            swarm.AddDrone(new Drone(new Point(0,1),1, 10));
        }

        new Thread(() => StartDrawing(swarm)).Start();

        Operator @operator = new Operator(swarm);
        Thread.Sleep(1000);
        @operator.MoveSwarmToPoint(new Point(50, 50));
    }

    static void StartDrawing(Swarm swarm)
    {
        Drawing drawing = new(swarm, 300, 300);
        drawing.Start();
    }
}
