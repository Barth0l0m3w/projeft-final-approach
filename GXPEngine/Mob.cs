﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

internal class Mob : AnimationSprite
{
    const int NORMAL = 0;
    const int HAPPY = 1;
    const int BURNING = 2;
    int currentState = NORMAL;

    public Mob(TiledObject obj = null) : base("mob_spritesheet.png", 7, 1)
    {
        // SetOrigin(width / 2, height / 2);
        //width =(int)obj.Width;
       // height = (int)obj.Height;
        
    }

    private void Update()
    {
        AnimateCharacter();
        AnimationCycles();
        //Gizmos.DrawRectangle(0, 0, width, height, this);

    }

    private void AnimateCharacter()
    {
        switch (currentState)
        {
            case NORMAL:
                SetCycle(0, 2);
                Animate(0.09f);
                break;
            case HAPPY:
                SetCycle(2, 2);
                Animate(0.15f);
                break;
            case BURNING:
                Console.WriteLine("BURN BABY BURN");
                SetCycle(4, 3);
                Animate(0.2f);
                break;
        }
    }

    private void AnimationCycles()
    {
        if (((MyGame)game).mobHit == true)
        {
            currentState = BURNING;
        }

        if (((MyGame)game).isBurning == true)
        {
            currentState = HAPPY;
        }
        if (Input.GetKeyUp(Key.N))
        {
            currentState = NORMAL;
        }
    }
}

