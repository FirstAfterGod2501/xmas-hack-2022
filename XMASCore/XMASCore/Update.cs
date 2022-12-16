namespace XMASCore;

public enum Action
{
    stay,
    move,
    returnInbase,
    work,
    sayCoords
}

public class Update
{
    public int id { get; }

    public Action Action { get; }

    public int x { get; }

    public int y { get; }

    public int jumpCount { get; set; }

    public int maxJumpCounts { get; set; }
}