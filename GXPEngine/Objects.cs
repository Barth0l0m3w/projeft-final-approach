using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


public abstract class Objects : Sprite //heritance class
{
    public Vec2 Position //getting the object position when moving them
    {
        get
        {
            return _position;
        }

        set
        {
            _position = value;
        }
    }

    private static SoundChannel soundChannel2 = new SoundChannel(2);
    private static Sound spell = new Sound("spell_sneeze.wav");

    protected bool clicked = false;
    public bool inSpellRange = false;
    private bool clickedOnce = false;

    protected Vec2 _position;
    protected Vec2 mouseP;
    protected Vec2 distance;

    public Objects( string image) : base(image)
    {
        inSpellRange = false;
        SetOrigin(width / 2, height / 2);
    }

    protected virtual void UpdateScreenPosition()
    {
        //setting the new position coordenates when having the object picked up
        x = _position.x;
        y = _position.y;
    }

    protected void OnCollision(GameObject Other)
    {
        //when the object is in spellrange make the boolean true to be able to place the objects
        if (Other is CollisionSpellRange)
        {
            inSpellRange = true;
        }
    }

    protected void MouseTouching()
    {
        if (HitTestPoint(Input.mouseX, Input.mouseY))
        {
            if (!clicked && Input.GetMouseButtonUp(0) && !((MyGame)game).itemPicked)
            {
                //activating that the item is picked so no others can also be picked
                clicked = true;
                clickedOnce = true;
                ((MyGame)game).itemPicked = true;
            }

            else if (clicked && Input.GetMouseButtonUp(0) && inSpellRange)
            {
                //placing the objects in the spellrange when thei're picked 
                soundChannel2 = spell.Play();
                clicked = false;

                //deactvating the boolians to be able to pick up new objects
                ((MyGame)game).itemPicked = false;
                ((MyGame)game).animWitch = true;
            }

            else
            {
                ((MyGame)game).spellPlaced = false;
            }
        }
    }

    protected void UpdateMousePosition()
    {
        mouseP.x = Input.mouseX;
        mouseP.y = Input.mouseY;

        if (clicked && !((MyGame)game).torchMoving)
        {
            //moving the objects with the mouse after thei're picked up
            _position.x = Input.mouseX;
            _position.y = Input.mouseY;

            UpdateScreenPosition();
           Grow();
        }
    }

    private void Grow()
    {
        if (clickedOnce)
        {
            scale = 2;
        }
    }

    protected void Step()
    {
        UpdateMousePosition();
        MouseTouching();
        inSpellRange = false;

        _position.x = x;
        _position.y = y;
    }
}

