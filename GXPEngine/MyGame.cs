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
        //// Draw some things on a canvas:
        //EasyDraw canvas = new EasyDraw(800, 600);
        //AddChild(canvas);

        //spellRange = new SpellRange(3, 3, width / 2, height / 2);
        //AddChild(spellRange);

        //mushroom = new Mushroom();
        //AddChild(mushroom);

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

		if (Input.GetKeyDown(Key.R))
		{
			Console.WriteLine("Reloading the level " + levelName);
			LoadLevel(levelName);
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