using System;
using GXPEngine;
using System.Drawing;
using System.Collections.Generic;

public class MyGame : Game
{
    public LevelLoader level;
    SceneManager sceneManager;

    public bool torchMoving = false;
    public bool isBurning = false;
    public bool mobHit = false;
    public bool startTorch = false;

    public String CurrentLevel = null;

    public MyGame() : base(1920, 1080, false, false, 960, 540)
    {
        sceneManager = new SceneManager();
        AddChild(sceneManager);

        SceneManager.Instance.LoadLevel("Level_1_final_9_05_2022");
        CurrentLevel = "Level_1_final_9_05_2022";
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