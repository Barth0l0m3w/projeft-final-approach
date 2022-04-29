using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class SpellRange : Sprite
{


    public SpellRange(TiledObject obj = null) : base("colors.png", false)
    {
        

        SetOrigin(width / 2, height / 2);

        Sprite collisionRange = new Sprite("colors.png", true, true);
        collisionRange.SetScaleXY(scaleX/2, scaleY/2);
        collisionRange.SetOrigin(width/2, height/2);
        AddChild(collisionRange);
    }
}

