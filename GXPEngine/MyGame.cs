using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;							// System.Drawing contains drawing tools such as Color definitions

public class MyGame : Game
{
	Ball ball;
	Mushroom mushroom;

	public MyGame() : base(800, 600, false)		// Create a window that's 800x600 and NOT fullscreen
	{
		ball = new Ball(64, 64, new Vec2(width/2, height/2), new Vec2(0,1));
		AddChild(ball);

		mushroom = new Mushroom(new Vec2(width/2, height - 50), 64, 64);
		AddChild(mushroom);

	}

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
		// Empty
	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
	}
}