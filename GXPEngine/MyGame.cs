using System;
using GXPEngine;
using System.Drawing;
using System.Collections.Generic;

public class MyGame : Game
{
    public LevelLoader level;
    SceneManager sceneManager;
    public bool torchMoving = false;

    public MyGame() : base(1920, 1080, false, false, 960, 540)
    {
        sceneManager = new SceneManager();
        AddChild(sceneManager);

        SceneManager.Instance.LoadLevel("map_prototype_big");
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
        if (Input.GetKey(Key.L))
        {
            SceneManager.Instance.LoadLevel("map_prototype");
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

    /*private void LoadLevel(string filename)
    {
        DestroyAll();
        level = new LevelLoader(filename);
        LateAddChild(level);
    }*/
}