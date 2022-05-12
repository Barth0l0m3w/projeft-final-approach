using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;
using GXPEngine;


public class Collectable : Sprite
{

    public Collectable(TiledObject obj = null) : base("bottle_sprite.png")
    {
        SetOrigin(width/2, height/2);
    }

    private void CheckCollisions()
    {
        GameObject[] collisions = GetCollisions();
        for (int i = 0; i < collisions.Length; i++)
        {
            if (collisions[i] is Torch)
            {
                ((MyGame)game).collectibleGrabbed = true;
                LateDestroy();
            }
        }
    }

    private void DeleteIfNotCollected()
    {
        if (((MyGame)game).isBurning || ((MyGame)game).voidTouched || ((MyGame)game).mobHit)
        {
            LateDestroy();
        }
    }

    private void Update()
    {
        CheckCollisions();
        DeleteIfNotCollected();
    }
}

