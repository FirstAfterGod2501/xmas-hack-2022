using System.Net.Mime;
using SFML.Graphics;

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
            if (swarmDrone.Position.X == point.X && swarmDrone.Position.Y == point.Y && swarmDrone != drone)
            {
                return true;
            }
        }

        return false;
    }
    
    public static bool IsCoccupiedPoint(Point point,  List<Drone> drones, Drone drone)
    {
        foreach (var swarmDrone in drones)
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
                double tempDistance = PointDistance(tempPosition, endPoint);
                if (tempDistance < bestDistance && Math.Min(tempPosition.X, tempPosition.Y) >= 0 &&!IsCoccupiedPoint(tempPosition, swarm, drone))
                {
                    bestDistance = tempDistance;
                    bestDirection = new Direction(x, y);
                }
            }
        }

        return bestDirection;
    }
    
    public static Direction FineDestDirection(Drone drone, Point endPoint, List<Drone> drones)
    {
        double bestDistance = Double.MaxValue;
        Direction bestDirection = new Direction(0, 0);
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                Point tempPosition = new Point(drone.Position.X + x*drone.Speed, drone.Position.Y + y*drone.Speed);
                double tempDistance = CalculatTool.PointDistance(tempPosition, endPoint);
                if (tempDistance < bestDistance && !IsCoccupiedPoint(tempPosition, drones, drone))
                {
                    bestDistance = tempDistance;
                    bestDirection = new Direction(x, y);
                }
            }
        }

        return bestDirection;
    }

    public static Point FarestPoint(List<Point> points, Point position)
    {
        Point res = new Point(-1, -1);
        double max = Double.MinValue;
        foreach (var point in points)
        {
            double tempMax = CalculatTool.PointDistance(point, position);
            if (tempMax > max)
            {
                max = tempMax;
                res = point;
            }
        }

        return res;
    }

    public static Point FindPoint(Point point1, Point point2, double length)
    {
        double Rab = PointDistance(point1, point2);
        double k = length / Rab;
        return new Point((int)(point1.X + (point2.X + point1.X) * k), (int)(point1.Y + (point2.Y + point1.Y) * k));
    }
}