namespace XMASCore;

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
        
        
    }
    public override bool Equals(object? obj)
    {
        Point point = (Point)obj;
        return this.X == point.X && this.X == point.X;
    }
}

public class Direction
{
    public int DeltaX { get; set; }
    public int DeltaY { get; set; }

    public Direction(int deltaX, int deltaY)
    {
        DeltaX = deltaX;
        DeltaY = deltaY;
    }
}