using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using GXPEngine.Core;
using TiledMapParser;


class Mushroom : Objects //having it be inherited from Objects
{
    public Collider boxCollider;
    public Vec2 position;
    
    private int angle;
    public bool isClicked;

    public Mushroom(TiledObject obj = null) : base("mushroom.png")
    {
        Position = new Vec2(obj.X, obj.Y);
        height = (int)obj.Height;
        width = (int)obj.Width;
        SetOrigin(width/2,height/2);

        angle = obj.GetIntProperty("angle", 0);
        boxCollider = createCollider();

        rotation = angle;
        isClicked = clicked;
    }

    void Update()
    {
        Step();
    }
}

