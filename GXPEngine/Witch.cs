using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

internal class Witch : AnimationSprite
{
    private bool spell = false;
    private bool free = false;
    private bool stopAnimating = false;

    const int NORMAL = 0;
    const int BURNING = 1;
    const int SPELL = 2;
    const int FREE = 3;

    const int notMirrored = 0;
    const int isMirrored = 1;

    private int currentState = NORMAL;
    private int mirrored = 0;

    public Witch(TiledObject obj = null) : base("witch_trimmed.png", 5, 5)
    {
        SetOrigin(width / 2, height / 2);
        mirrored = obj.GetIntProperty("mirrored", 0);
    }

    void Update()
    {
        if (!stopAnimating)
        {
            AnimateCharacter();
            AnimMirror();
        }
        AnimationCycles();
    }

    private void MirrorAll(bool mirrorX, bool mirrorY = false)
    {
        Mirror(mirrorX, mirrorY);
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

    private void AnimMirror()
    {
        switch (mirrored)
        {
            case notMirrored:
                //nothing
                break;
            case isMirrored:
                MirrorAll(true);
                break;

        }
    }

    private void AnimationCycles()
    {
        if (((MyGame)game).isBurning == true)
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

        if (((MyGame)game).animWitch == true)
        {
            currentState = SPELL;

            if (currentFrame == 21)
            {
                spell = false;
                currentState = NORMAL;
                ((MyGame)game).spellPlaced = false;
                ((MyGame)game).animWitch = false;
            }
        }

        if (((MyGame)game).mobHit == true)
        {
            currentState = FREE;
            if (currentFrame == 14)
            {
                stopAnimating = true;
                free = false;
                currentState = NORMAL;
            }
        }
    }
}