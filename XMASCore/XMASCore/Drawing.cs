namespace XMASCore;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

public class Drawing
{
    private RenderWindow Window;
    
    private Sprite BackgroundImage;
    private Swarm Swarm;

    public Drawing(Swarm swarm, uint width, uint height)
    {
        Swarm = swarm;
        Window = new RenderWindow(new VideoMode(width, height), "Title");
        Window.SetVerticalSyncEnabled(true);
        Image image = new Image("Fields/img.png");
        BackgroundImage = new Sprite(new Texture(image));
        BackgroundImage.Scale = new Vector2f((float)width / image.Size.X, (float)height / image.Size.Y);
        
    }

    public static void Start(Swarm swarm, uint width, uint height)
    {
        Drawing drawing = new(swarm, width, height);
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
            Window.Draw(BackgroundImage);
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