using System;
using GXPEngine;
using System.Drawing;
using System.Collections.Generic;

public class MyGame : Game
{
	string levelName = "map_prototype_big.tmx";
	Levels level;

	public MyGame() : base(1920, 1080, false, false, 960, 540)
	{

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

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
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