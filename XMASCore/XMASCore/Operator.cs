namespace XMASCore;

public class Operator
{
    public Swarm Swarm { get; protected set; }

    public Operator(Swarm swarm)
    {
        Swarm = swarm;
    }

    private void MoveDrone(Drone drone, Point point)
    {
        drone.Direction = CalculatTool.FineDestDirection(drone, point, Swarm);
        drone.Move();
    }

    public void MoveSwarmToPoint(Point point)
    {
        while (Swarm.Master.Position!=point)
        {
            MoveDrone(Swarm.Master, point);
            Thread.Sleep(100);
        }
    }
}