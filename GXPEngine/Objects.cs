using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


public abstract class Objects : Sprite
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

    public Objects(Vec2 pPosition, string image) : base(image)
    {
        _position = pPosition;
        SetOrigin(width / 2, height / 2);
    }

    protected virtual void UpdateScreenPosition()
    {
        x = _position.x;
        y = _position.y;
    }

    protected void OnCollision()
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

    protected void UpdateMousePosition()
    {
        mouseP.x = Input.mouseX;
        mouseP.y = Input.mouseY;

        if (clicked)
        {
            _position.x = Input.mouseX;
            _position.y = Input.mouseY;
        }
    }

    protected void Step()
    {
        UpdateMousePosition();
        UpdateScreenPosition();
        OnCollision();
        distance = mouseP - Position;
    }
}

