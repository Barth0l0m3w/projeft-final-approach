using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;


public class ReloadButton : Sprite
{
    private Vec2 Position
    {
        get
        { return _position; }
    }

    private Vec2 _position;
    private Vec2 distance;
    private Vec2 mouseP;
    private bool clicked = false;

    public ReloadButton(TiledObject obj = null) : base("square.png")
    {
        SetOrigin(width / 2, height / 2);
    }

    private void Update()
    {
        clicked = false;

        _position.x = x;
        _position.y = y;
        Step();
    }

    private void MouseTouching()
    {
        if (distance.Length() <= width/2)
        {
            Console.WriteLine("NOW");
            if (!clicked && Input.GetMouseButtonUp(0))
            {
                clicked = true;
                Console.WriteLine(clicked);
            }
        }
    }
    private void UpdateMousePosition()
    {
        mouseP.x = Input.mouseX;
        mouseP.y = Input.mouseY;
    }

    void Step()
    {
        distance = mouseP - Position;
        MouseTouching();
        UpdateMousePosition();
    }
}


