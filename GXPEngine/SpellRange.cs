using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


public class SpellRange : Sprite
{


    public SpellRange(float _ScaleX, float _ScaleY, float _x, float _y) : base("colors.png", false)
    {
        scaleX = _ScaleX;
        scaleY = _ScaleY;
        x = _x;
        y = _y;

        SetOrigin(width / 2, height / 2);

        Sprite collisionRange = new Sprite("colors.png", true, true);
        collisionRange.SetScaleXY(scaleX/2, scaleY/2);
        collisionRange.SetOrigin(width/2, height/2);
        AddChild(collisionRange);
    }
}

