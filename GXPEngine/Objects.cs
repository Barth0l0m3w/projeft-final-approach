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

    //protected Vec2 velocity;
    protected bool clicked = false;
    protected bool inSpellRange = false;

    protected Vec2 _position;
    protected Vec2 mouseP;
    protected Vec2 distance;

    public Objects( string image) : base(image)
    {
        
        SetOrigin(width / 2, height / 2);
    }

    protected virtual void UpdateScreenPosition()
    {
        x = _position.x;
        y = _position.y;
    }
    protected void OnCollision(GameObject Other)
    {
        if (Other is CollisionSpellRange)
        {
            inSpellRange = true;
        }
    }

    protected void MouseTouching()
    {
        if (distance.Length() <= this.width/2)
        {
            if (!clicked && Input.GetMouseButtonUp(0))
            {
                clicked = true;
            }
            else if (clicked && Input.GetMouseButtonUp(0) && inSpellRange)
            {
                clicked = false;
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
            UpdateScreenPosition();
        }
    }

    protected void Step()
    {
        UpdateMousePosition();
        MouseTouching();
        inSpellRange = false;
        distance = mouseP - Position;

        _position.x = x;
        _position.y = y;
    }
}

