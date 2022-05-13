using System;
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
    int currentState = NORMAL; //have idle as default

    public Mob(TiledObject obj = null) : base("mob_spritesheet.png", 7, 1)
    {   
    }

    private void Update()
    {
        //animating the correct animation at the correct moments
        AnimateCharacter();
        AnimationCycles();
    }

    private void AnimateCharacter()
    {
        switch (currentState)
        {
            case NORMAL: //idle
                SetCycle(0, 2);
                Animate(0.09f);
                break;
            case HAPPY: //witch burning (level lost)
                SetCycle(2, 2);
                Animate(0.15f);
                break;
            case BURNING://mob burning (level won)
                SetCycle(4, 3);
                Animate(0.2f);
                break;
        }
    }

    private void AnimationCycles()
    {
        //mob burning
        if (((MyGame)game).mobHit == true)
        {
            currentState = BURNING;
        }

        //witch burning
        if (((MyGame)game).isBurning == true)
        {
            currentState = HAPPY;
        }
    }
}

