namespace XMASCore;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

public class Drawing
{
    private RenderWindow Window;
    
    private Swarm Swarm;
    private List<Sprite> Images;

    public Drawing(Swarm swarm, string[] imageFilePaths, uint width, uint height)
    {
        Images = new List<Sprite>();
        Swarm = swarm;
        Window = new RenderWindow(new VideoMode(width, height), "Title");
        Window.SetVerticalSyncEnabled(true);
        
        foreach (var path in imageFilePaths)
        {
            Image image = new Image(path);
            Sprite sprite = new Sprite(new Texture(image));
            sprite.Scale = new Vector2f((float)width / image.Size.X, (float)height / image.Size.Y);
            Images.Add(sprite);
        }
    }

    public static void Start(Swarm swarm, string[] imageFilePaths, uint width, uint height)
    {
        Drawing drawing = new(swarm, imageFilePaths, width, height);
        drawing.Display();
    }
    

    static void OnClose(object sender, EventArgs e)
    {
        RenderWindow win = (RenderWindow)sender;
        win.Close();
    }

    public void Display()
    {
        Window.Closed += OnClose;
        while (Window.IsOpen)
        {
            Window.DispatchEvents();
            Window.Clear();
            foreach (var image in Images)
            {
                Window.Draw(image);
            }
            foreach (var drone in Swarm.Drones)
            {
                DrawDrone(drone);
            }
            Window.Display();
        }
    }

    public void DrawDrone(Drone drone)
    {
        CircleShape dot = new CircleShape(2);
        dot.FillColor = Color.Red;
        dot.Position = new Vector2f(drone.Position.X, drone.Position.Y);
        Window.Draw(dot);
    }
}