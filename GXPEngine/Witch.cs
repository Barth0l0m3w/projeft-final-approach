using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

internal class Witch : AnimationSprite
{
    private float animTimer = 0;
    private float waitTime = 1f;
    private bool spell = false;
    private bool free = false;
    private bool stop = false;

    const int NORMAL = 0;
    const int BURNING = 1;
    const int SPELL = 2;
    const int FREE = 3;
    int currentState = NORMAL;

    public Witch(TiledObject obj = null) : base("witch_spritesheet.png", 5, 5)
    {

        SetOrigin(width / 2, height / 2);
    }

    void Update()
    {
        if (!stop)
        {
            AnimateCharacter();
        }

        AnimationCycles();
    }

    private void AnimateCharacter()
    {
        switch (currentState)
        {
            case NORMAL:
                SetCycle(0, 10);
                Animate(0.06f);
                break;
            case BURNING:
                SetCycle(22, 3);
                Animate(0.07f);
                break;
            case SPELL:
                SetCycle(19, 3);
                Animate(0.07f);
                break;
            case FREE:
                SetCycle(9, 6);
                Animate(0.2f);
                break;
        }
    }

    private void AnimationCycles()
    {
        if (Input.GetKeyUp(Key.B))
        {
            currentState = BURNING;
        }
        if (Input.GetKeyDown(Key.S))
        {
            spell = true;
        }
        if (Input.GetKeyUp(Key.F))
        {
            free = true;
        }

        if (spell)
        {
            currentState = SPELL;
            if (currentFrame == 21)
            {
                spell = false;
                currentState = NORMAL;
            }
        }

        if (free)
        {
            Console.WriteLine(currentFrame);
            currentState = FREE;
            if (currentFrame == 14)
            {
                stop = true;
                free = false;
                currentState = NORMAL;
            }
        }
    }
}