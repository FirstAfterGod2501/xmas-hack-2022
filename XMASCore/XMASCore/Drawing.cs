namespace XMASCore;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

public class Drawing
{
    private RenderWindow Window;
    private Sprite BackgroundImage;

    public Drawing(uint width, uint height)
    {
        Window = new RenderWindow(new VideoMode(width, height), "Title");
        BackgroundImage = new Sprite(new Texture(new Image("Fields/img.png")));
    }

    public void Display()
    {
        while (true)
        {
            
        }
    }

    public void DrawDrone(Drone drone)
    {
        CircleShape dot = new CircleShape(5);
        dot.FillColor = Color.Red;
        dot.Position = new Vector2f(drone.Position.X, drone.Position.Y);
        Window.Draw(dot);
    }
}