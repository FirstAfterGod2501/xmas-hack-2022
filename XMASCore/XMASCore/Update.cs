namespace XMASCore;

public enum Action
{
    stay,
    move,
    returnInbase,
    work,
    sayCoords,
    sayCoordsResponse
}

public class Update
{
    public Update(int fromId,int id, Action action,int maxJumpCounts,int x,int y)
    {
        Id = id;
        Action = action;
        X = x;
        Y = y;
        this.maxJumpCounts = maxJumpCounts;
        FromId = fromId;
    }

    public int FromId { get; set; }

    public int Id { get; }

    public Action Action { get; }

    public int X { get; }
    public int Y { get; }

    public int jumpCount { get; set; }

    public int maxJumpCounts { get; set; }
}