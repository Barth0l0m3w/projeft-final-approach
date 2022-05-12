using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;
using GXPEngine;


public class Collectable : Sprite
{

    public Collectable(TiledObject obj = null) : base("star_full.png")
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

    private void Update()
    {
        CheckCollisions();
    }
}

