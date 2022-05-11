using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;


public class Button : Sprite
{
    private Vec2 Position
    {
        get
        { return _position; }
    }

    private Vec2 _position;
    private Vec2 distance;
    private Vec2 mouseP;
    private bool clicked = false;
    private string levelName = null;
    private int function = 0;
    //private int levelNumber = 1;
    private string image = null;

    public Button(TiledObject obj = null) : base("square.png")
    {
        //SetOrigin(width / 2, height / 2);
        levelName = obj.GetStringProperty("levelName", null);
        function = obj.GetIntProperty("function", 0);
        image = obj.GetStringProperty("image", null);
    }

    private void Update()
    {
        _position.x = x;
        _position.y = y;
        Step();
    }

    private void MouseTouching()
    {
        if (distance.Length() <= width / 2)
        {

            if (Input.GetMouseButtonUp(0))
            {
                clicked = true;
            }
        }
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

    private void LastLevel()
    {
        SceneManager.Instance.LoadLevel(levelName);
    }

    private void UpdateMousePosition()
    {
        mouseP.x = Input.mouseX;
        mouseP.y = Input.mouseY;
    }

    void Step()
    {
        distance = mouseP - Position;
        MouseTouching();
        UpdateMousePosition();
        ChooseFunction();
        MoveButton();
    }

    void MoveButton()
    {
        if (((MyGame)game).mobHit && function == 0 || ((MyGame)game).voidTouched && function == 0 || Input.GetKeyUp(Key.Q))
        {
            x = ((MyGame)game).width/2;
            y = ((MyGame)game).height/2;
        }
    }

    public void ChooseFunction()
    {
        switch (function)
        {
            case 0: //next level
                if (clicked)
                {
                    GoLevel();
                };
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
        }
    }
}


