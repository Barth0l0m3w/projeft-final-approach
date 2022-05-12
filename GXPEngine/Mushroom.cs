﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using GXPEngine.Core;
using TiledMapParser;

class Mushroom : Objects
{
    public Vec2 position;
    public Collider boxCollider;
    private int angle;
    public bool isClicked;

    public Mushroom(TiledObject obj = null) : base("mushroom.png")
    {
        Position = new Vec2(obj.X, obj.Y);
        height = (int)obj.Height;
        width = (int)obj.Width;
        SetOrigin(width/2,height/2);

        isClicked = clicked;

        //x = Position.x;
       // y = Position.y;

        angle = obj.GetIntProperty("angle", 0);
        boxCollider = createCollider();

        rotation = angle;
        //obj.Rotation = angle;
        //rotation = 45;
    }

    void Update()
    {
        Step();
        //rotation = angle;
        Gizmos.DrawRectangle(0, 0, texture.width, texture.height, this);
    }
}

