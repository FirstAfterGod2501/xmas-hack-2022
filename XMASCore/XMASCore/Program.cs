namespace XMASCore;

class Program
{
    static void Main()
    {
        Swarm swarm = new Swarm(10);
        for (int i = 0; i < 10; i++)
        {
            swarm.AddDrone(new Drone(new Point(0,i),1, 10));
        }

        Console.WriteLine();
    }
}
