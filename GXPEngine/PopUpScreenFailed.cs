using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;
    internal class PopUpScreenFailed : Sprite
    {
    public  PopUpScreenFailed(TiledObject obj = null): base("level_fail_book.png")
    {

    }

    void Update()
    {
        if (((MyGame)game).isBurning)
        {
            Console.WriteLine("Game lost");
            x = ((MyGame)game).width/2;
            y = ((MyGame)game).height/2;
        }
    }

    }

