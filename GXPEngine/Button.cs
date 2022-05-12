﻿using System;
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

    public Button(TiledObject obj = null) : base("square.png")
    {
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
        if (HitTestPoint(Input.mouseX, Input.mouseY))
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

    private void UpdateMousePosition()
    {
        mouseP.x = Input.mouseX;
        mouseP.y = Input.mouseY;
    }

    void Step()
    {
        MouseTouching();
        UpdateMousePosition();
        ChooseFunction();
        MoveButton();
    }

    void MoveButton()
    {
        if (((MyGame)game).mobHit && function == 0)
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
            case 1: //reload
                if (clicked)
                {
                    CurrentLoad();
                }
                break;
            case 2: //Start torch
                if (clicked)
                {
                    ((MyGame)game).startTorch = true;
                }
                break;
        }
    }
}


