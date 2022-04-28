using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
using System.Collections.Generic;

public class MyGame : Game
{
	Ball ball;
	Mushroom mushroom;
	string levelName = "map_prototype_big.tmx";
	Levels level;

	static void DoTests()
    {
		Vec2 a = new Vec2(0.4f, -0.5f);
		a.WeirdNormalize();
        Console.WriteLine("This should be (0.8,-1): "+a);
    }


	public MyGame() : base(1920, 1080, false, false, 960,540) // alternative: use settings instead. (See last lecture from Game Programming)		
	{
		//ball = new Ball(32, new Vec2(1800, 200), new Vec2(0,0));
		//AddChild(ball);

		//mushroom = new Mushroom(new Vec2(350, height - 200), 200, 60);
		//AddChild(mushroom);
		//mushroom.rotation = -110;

	}

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
		if (Input.GetKey(Key.SPACE))
        {
			targetFps = 5;
        } else
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
		DoTests();
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