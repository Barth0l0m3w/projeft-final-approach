using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;


public class Button : Sprite
{
    private Vec2 _position;
    private Vec2 mouseP;

    private bool clicked = false;
    private string levelName = null;
    private int function = 0;
    private string image = null;

    TiledObject obj;

    public Button(TiledObject obj = null) : base("square.png")
    {
        levelName = obj.GetStringProperty("levelName", null);
        function = obj.GetIntProperty("function", 0);
        image = obj.GetStringProperty("image", null);
        alpha = 0;

        this.obj = obj;
        HierarchyManager.Instance.LateCall(ButtonSprite); // this would call it after update is done (and after the TiledLoader has set scale). But in this case, that's not needed.

        ((MyGame)game).startTorch = false;
    }

    private void Update()
    {

        if (HitTestPoint(Input.mouseX, Input.mouseY))
        {
            SetColor(1, 0, 0);
        }
        else
        {
            SetColor(1, 1, 1);
        }

        _position.x = x;
        _position.y = y;
        Step();
    }

    private void MouseTouching()
    {
        if (HitTestPoint(Input.mouseX, Input.mouseY))
        {
            if (Input.GetMouseButtonUp(0))
            {
                clicked = true;
            }
            else
            {
                clicked = false;
            }
        }
    }

    private void CurrentLoad()
    {
        //resetting the current level
        SceneManager.Instance.LoadLevel(((MyGame)game).CurrentLevel);
    }

    private void GoLevel()
    {
        //loading the new level in
        SceneManager.Instance.LoadLevel(levelName);

        //setting the current level to the new level
        ((MyGame)game).CurrentLevel = levelName;
    }

    private void UpdateMousePosition()
    {
        //getting the position from the mouse coordenates
        mouseP.x = Input.mouseX;
        mouseP.y = Input.mouseY;
    }

    void Step()
    {
        MouseTouching();
        UpdateMousePosition();

        if (clicked)
        {
            ChooseFunction();
        }

        MoveButton();
    }

    void MoveButton()
    {
        if (((MyGame)game).mobHit || ((MyGame)game).voidTouched || Input.GetKeyUp(Key.Q))
        {
            x = 1074 + width / 2;

            switch (function)
            {
                case 0:
                    y = 280;
                    break;
                case 1:
                    y = 460;
                    break;
                case 5:
                    y = 640;
                    break;
                default: break;
            }

            y += height / 2;
        }

        if (((MyGame)game).isBurning)
        {
            x = 1074 + width / 2;
            switch (function)
            {
                case 0:
                    y = 2000;
                    break;
                case 1:
                    y = 360;
                    break;
                case 5:
                    y = 586;
                    break;
                default: break;
            }

            y += height / 2;
        }

        if (((MyGame)game).startTorch && function == 2)
        {
            x = 3000 + 64;
            y = 2000 + 64;
        }
    }

    void ButtonSprite()
    {
        switch (function)
        {
            case 0:
                LateAddChild(PrepareSprite("Next Button.png"));
                break;
            case 1:
                LateAddChild(PrepareSprite("Replay.png"));
                break;
            case 2:
                LateAddChild(PrepareSprite("Burn Button.png"));
                break;
            case 3:
                LateAddChild(PrepareSprite("Play.png"));
                break;
            case 4:
                LateAddChild(PrepareSprite("QuitMain.png"));
                break;
            case 5:
                LateAddChild(PrepareSprite("Quit.png"));
                break;
            default:
                break;
        }
    }

    Sprite PrepareSprite(string spriteName)
    {
        Sprite sprite = new Sprite(spriteName);
        sprite.SetOrigin(sprite.width / 2, sprite.height / 2);

        // this is because a child already inherits the scale values from its parent, so using widht & height would apply it twice:
        // However, we still want to scale relative to the width of this vs width of sprite (child).
        sprite.width = texture.width;
        sprite.height = texture.height;

        return sprite;
    }

    public void ChooseFunction()
    {
        switch (function)
        {
            case 0: //next level
                GoLevel();
                break;

            case 1: //restart level
                if (clicked)
                {
                    CurrentLoad();
                    ((MyGame)game).stopSound = true;
                }
                break;

            case 2: //start torch
                if (clicked)
                {
                    ((MyGame)game).startTorch = true;
                }
                break;

            case 3: //start game
                if (clicked)
                {
                    GoLevel();
                }
                break;

            case 4: //quit game
                if (clicked)
                {
                    ((MyGame)game).Destroy();
                }
                break;

            case 5: //small quit
                if (clicked)
                {
                    ((MyGame)game).Destroy();
                }
                break;

            default:
                break;
        }

        clicked = false;
    }
}


