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
    Sprite spr = new Sprite("bottle_sprite.png");
    int stars = 0;

    public Star(TiledObject obj = null) : base("bottle_empty.png")
    {
        starType = obj.GetIntProperty("completed", 0);
        spr.SetOrigin(width / 2, height / 2);
        AddChild(spr);
        spr.alpha = 0;
    }

    private void ShowRightStar()
    {
        //if (starType == 1 && ((MyGame)game).voidTouched)
        //{
        //    AddChild(spr);
        //    if (starType == 3 && ((MyGame)game).collectibleGrabbed)
        //    {
        //        AddChild(spr);
        //    }
        //}
        //else if (starType == 2 && ((MyGame)game).mobHit || starType == 1 && ((MyGame)game).mobHit)
        //{
        //    AddChild(spr);
        //    if (starType == 3 && ((MyGame)game).collectibleGrabbed)
        //    {
        //        AddChild(spr);
        //    }
        //}

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
            switch (starType)
            {
                case 1:
                    x = ((MyGame)game).width/2 - width - 40;
                    //y = 180+height/2;
                    break;
                case 2:
                    x = ((MyGame)game).width/2;
                   // y = ((MyGame)game).y;
                    break;
                case 3:
                    x = ((MyGame)game).width/2 + width + 40;
                   // y = ((MyGame)game).y;
                    break;
                default:
                    break;
            }

            y = 180 + height / 2;
        }
    }

    void Update()
    {
        MoveStars();
        ShowRightStar();
    }
}

