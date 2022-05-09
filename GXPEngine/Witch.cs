using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

internal class Witch : Sprite
{
    Sprite burned = new Sprite("witch_burn.png");
    public bool isBurning = false;
    public Witch(TiledObject obj = null) : base("witch.png")
    {
        burned.SetOrigin(width/2, height/2);
        AddChild(burned);
        burned.alpha = 0;
        SetOrigin(width/2,height/2);
    }

    void Update()
    {
        if (isBurning)
        {
            burned.alpha = 1;
            alpha = 0;
        } 
    }
}

