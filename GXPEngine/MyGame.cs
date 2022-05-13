using System;
using GXPEngine;
using System.Drawing;
using System.Collections.Generic;


public class MyGame : Game
{
    public static MyGame instance
    {
        get
        {
            return (MyGame)Game.main;
        }
    }

    public bool stopSound = false;
    public bool torchMoving = false;
    public bool isBurning = false;
    public bool mobHit = false;
    public bool startTorch = false;
    public bool popupSpawned = false;
    public bool spellPlaced = false;
    public bool itemPicked = false;
    public bool animWitch = false;
    public bool voidTouched = false;
    public bool collectibleGrabbed = false;

    public String CurrentLevel = null;

    public LevelLoader level;

    SceneManager sceneManager;

    public MyGame() : base(1920, 1080, false, false, 960, 540)
    {
        //adding the scenemanager who will switch the correct chenes and destroys the old ones
        sceneManager = new SceneManager();
        AddChild(sceneManager);

        //SceneManager.Instance.LoadLevel("mainMenu");
        //CurrentLevel = "mainMenu";
        SceneManager.Instance.LoadLevel("Level_2_Final_9_05_2022");
        CurrentLevel = "Level_2_Final_9_05_2022";
    }

    void Update()
    {
        targetFps = 60;
    }

    static void Main()
    {
        new MyGame().Start();
    }
}