using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


public class Objects : Sprite
{
    public Vec2 Position
    {
        get
        {
            return _position;
        }
    }

    public Vec2 velocity;
    bool clicked = false;

    Vec2 _position;
    public Vec2 mouseP;
    Vec2 distance;

    public Objects(Vec2 pPosition) : base("circle.png")
    {
        _position = pPosition;
        UpdateScreenPosition();
        SetOrigin(width / 2, height / 2);
    }

    void UpdateScreenPosition()
    {
        x = _position.x;
        y = _position.y;
    }

    void OnCollision()
    {
        if (distance.Length() <= this.width)
        {
            if (!clicked && Input.GetMouseButtonUp(0))
            {
                clicked = true;
                //Console.WriteLine(clicked);
            }
            else if (clicked && Input.GetMouseButtonUp(0))
            {
                clicked = false;
                //Console.WriteLine(clicked + "SECOND");
            }
        }
    }

    void UpdateMousePosition()
    {
        mouseP.x = Input.mouseX;
        mouseP.y = Input.mouseY;

        if (clicked)
        {
            _position.x = Input.mouseX;
            _position.y = Input.mouseY;
        }
    }

    public void Step()
    {
        UpdateMousePosition();
        UpdateScreenPosition();
        OnCollision();
        distance = mouseP - Position;
    }
}

