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

    public LevelLoader level;
    SceneManager sceneManager;

    public bool torchMoving = false;
    public bool isBurning = false;
    public bool mobHit = false;
    public bool startTorch = false;
    public bool popupSpawned = false;

    public bool voidTouched = false;
    public bool collectibleGrabbed = false;
    public String CurrentLevel = null;

    public MyGame() : base(1920, 1080, false, false, 960, 540)
    {
        sceneManager = new SceneManager();
        AddChild(sceneManager);

        //SceneManager.Instance.LoadLevel("mainMenu");
        //CurrentLevel = "mainMenu";
        SceneManager.Instance.LoadLevel("mainMenu");
        CurrentLevel = "mainMenu";
    }

    void Update()
    {
        if (Input.GetKey(Key.SPACE))
        {
            targetFps = 5;
        }
        else
        {
            targetFps = 60;
        }

        if (collectibleGrabbed)
        {
            Console.WriteLine(collectibleGrabbed);
        }
    }

    static void Main()
    {
        new MyGame().Start();
    }

    private void DestroyAll()
    {
        List<GameObject> children = GetChildren();
        foreach (GameObject child in children)
        {
            child.LateDestroy();
        }
    }

  
}