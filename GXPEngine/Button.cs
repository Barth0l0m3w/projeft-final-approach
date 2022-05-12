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
        //ButtonSprite();
    }

    private void Update()
    {

        if (HitTestPoint(Input.mouseX,Input.mouseY))
        {
            //visible = false;
            SetColor(1, 0, 0);
        } else
        {
            //visible = true;
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
        }
        Console.WriteLine("Not touching");
    }

    private void CurrentLoad()
    {
        SceneManager.Instance.LoadLevel(((MyGame)game).CurrentLevel);
    }

    private void GoLevel()
    {
        SceneManager.Instance.LoadLevel(levelName);
        ((MyGame)game).CurrentLevel = levelName;
    }

    private void UpdateMousePosition()
    {
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
        if (((MyGame)game).mobHit && function == 0 || ((MyGame)game).voidTouched && function == 0 || Input.GetKeyUp(Key.Q))
        {
            x = 1588 + 64;
            y = 916 + 64;
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
                LateAddChild(PrepareSprite("nextLevel.png"));
                break;
            case 1:
                LateAddChild(PrepareSprite("restartLevel.png"));
                break;
            case 2:
                break;
            case 3:
                LateAddChild(PrepareSprite("Play.png"));
                break;
            case 4:
                LateAddChild(PrepareSprite("Quit.png"));
                break;
            default:
                break;
        }
    }

    Sprite PrepareSprite(string spriteName)
    {
        Sprite sprite = new Sprite(spriteName);
        sprite.SetOrigin(sprite.width/2, sprite.height/2);
        
        // this is because a child already inherits the scale values from its parent, so using widht & height would apply it twice:
        // However, we still want to scale relative to the width of this vs width of sprite (child).
        sprite.width = texture.width;
        sprite.height = texture.height;
        //sprite.alpha = 0.2f;
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
                }
                break;
            case 2: //start torch
                if (clicked)
                {
                    ((MyGame)game).startTorch = true;
                }
                break;
            case 3: //start game
                GoLevel();
                break;
            case 4: //quit game
                ((MyGame)game).Destroy();
                break;
            default:
                break;
        }
    }
}


