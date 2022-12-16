namespace XMASCore;

class Program
{
    static void Main()
    {
        Swarm swarm = new Swarm(10);
        for (int i = 0; i < 1; i++)
        {
            swarm.AddDrone(new Drone(new Point(0,i),1, 10));
        }

        new Thread(() => StartDrawing(swarm)).Start();

        Operator @operator = new Operator(swarm);
        
        @operator.MoveSwarmToPoint(new Point(50, 50));
    }

    static void StartDrawing(Swarm swarm)
    {
        Drawing drawing = new(ref swarm, 300, 300);
        drawing.Start();
    }
}
