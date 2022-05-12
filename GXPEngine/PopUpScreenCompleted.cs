using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;


internal class PopUpScreenCompleted : Sprite
{
    public PopUpScreenCompleted(TiledObject obj = null) : base("level_complete.png")
    {
    }

    void Update()
    {
        
        if (((MyGame)game).voidTouched || ((MyGame)game).mobHit)
        {
            Console.WriteLine("Gane Won");

            x = width/2;
            y = height/2;
        }
    }
}
