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