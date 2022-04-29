using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class CollisionSpellRange : Sprite
{


    public CollisionSpellRange(TiledObject obj = null) : base("colors.png", true)
    {
        alpha = 0.0f;
        SetOrigin(width / 2, height / 2);
    }
}

