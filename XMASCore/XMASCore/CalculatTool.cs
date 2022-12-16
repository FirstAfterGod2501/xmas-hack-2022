namespace XMASCore;

public class CalculatTool
{
    public static double PointDistance(Point point1, Point point2)
    {
        return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
    }

    public static bool IsCoccupiedPoint(Point point, Swarm swarm, Drone drone)
    {
        foreach (var swarmDrone in swarm.Drones)
        {
            if (swarmDrone == null)
            {
                continue;
            }
            if (swarmDrone.Position.Equals(point) && swarmDrone != drone)
            {
                return true;
            }
        }

        return false;
    }

    public static Direction FineDestDirection(Drone drone, Point endPoint, Swarm swarm)
    {
        double bestDistance = Double.MaxValue;
        Direction bestDirection = new Direction(0, 0);
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                Point tempPosition = new Point(drone.Position.X + x*drone.Speed, drone.Position.Y + y*drone.Speed);
                double tempDistance = CalculatTool.PointDistance(tempPosition, endPoint);
                if (tempDistance < bestDistance && !IsCoccupiedPoint(tempPosition, swarm, drone))
                {
                    bestDistance = tempDistance;
                    bestDirection = new Direction(x, y);
                }
            }
        }

        return bestDirection;
    }
    
}