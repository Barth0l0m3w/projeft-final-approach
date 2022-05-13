using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;


internal class Star : Sprite
{
    int starType;
    int stars = 0;

    Sprite spr = new Sprite("bottle_sprite.png");

    public Star(TiledObject obj = null) : base("bottle_empty.png")
    {
        starType = obj.GetIntProperty("completed", 0);
        spr.SetOrigin(width / 2, height / 2);
        AddChild(spr);
        spr.alpha = 0;
    }

    private void ShowRightStar()
    {

        if (((MyGame)game).voidTouched)
        {
            stars = 1;
            if (((MyGame)game).mobHit)
            {
                stars = 2;
                if (((MyGame)game).collectibleGrabbed)
                {
                    stars = 3;
                }
            }
        }

        else if (((MyGame)game).mobHit)
        {
            stars = 2;
            if (((MyGame)game).collectibleGrabbed)
            {
                stars = 3;
            }
        }

        switch (stars)
        {
            case 1:
                if (starType == 1)
                {
                    spr.alpha = 1;
                }
                break;
            case 2:
                if (starType != 3)
                {
                    spr.alpha = 1;
                }
                break;
            case 3:
                spr.alpha = 1;
                break;
            default:
                break;
        }
    }

    private void MoveStars()
    {
        if (((MyGame)game).voidTouched || ((MyGame)game).mobHit)
        {
            y = 460;

            switch (starType)
            {
                case 1:
                    x = 536;
                    break;
                case 2:
                    x = 630;
                    break;
                case 3:
                    x = 722;
                    break;
                default:
                    break;
            }
            x += width / 2;
            y += height / 2;
        }
    }

    void Update()
    {
        MoveStars();
        ShowRightStar();
    }
}

