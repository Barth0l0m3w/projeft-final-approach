using System;
using GXPEngine;
using System.Drawing;
using System.Collections.Generic;

public class MyGame : Game
{
    public string levelName = "map_prototype_big.tmx";
    public Levels level;

    public MyGame() : base(1920, 1080, false, false, 960, 540)
    {
        Console.WriteLine("Reloading the level " + levelName);
        LoadLevel(levelName);
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

    private void LoadLevel(string filename)
    {
        DestroyAll();
        level = new Levels(filename);
        LateAddChild(level);
    }
}