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
        set
        {
            _position = value;
        }
    }


    public Vec2 velocity;
    bool clicked = false;
    bool inSpellRange = false;

    Vec2 _position;
    public Vec2 mouseP;
    Vec2 distance;

    public Objects(string image) : base(image)
    {
       // SetOrigin(width / 2, height / 2);
       x= 0;
        y= 0;
        Console.WriteLine("position "+_position);
        
    }

    protected void UpdateScreenPosition()
    {
        x = _position.x;
        y = _position.y;
    }
    protected void OnCollision(GameObject Other)
    {
        if (Other is SpellRange)
        {
            inSpellRange = true;
        }
    }

    protected void MouseTouching()
    {
        if (distance.Length() <= this.width)
        {
            if (!clicked && Input.GetMouseButtonUp(0))
            {
                clicked = true;
                //Console.WriteLine(clicked);
            }
            else if (clicked && Input.GetMouseButtonUp(0) && inSpellRange)
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
        MouseTouching();
        inSpellRange = false;
        distance = mouseP - Position;
    }
}

