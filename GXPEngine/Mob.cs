using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

internal class Mob : Sprite
{
    Sprite actualSprite = new Sprite("mob.png", false, false);
    public Mob(TiledObject obj = null) : base("mob.png")
    {
        alpha = 0;
        actualSprite.width = width * 2;
        actualSprite.height = height * 2;
        actualSprite.SetOrigin(width/2, height/2);
        AddChild(actualSprite);
    }
}

