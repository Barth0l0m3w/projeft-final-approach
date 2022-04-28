using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;							// System.Drawing contains drawing tools such as Color definitions

public class MyGame : Game
{
	Ball ball;
	Mushroom mushroom;

	static void DoTests()
    {
		Vec2 a = new Vec2(0.4f, -0.5f);
		a.WeirdNormalize();
        Console.WriteLine("This should be (0.8,-1): "+a);
    }


	public MyGame() : base(1920, 1080, false, true)//, 960,540) // alternative: use settings instead. (See last lecture from Game Programming)		
	{
		ball = new Ball(32, new Vec2(1800, 200), new Vec2(0,0));
		AddChild(ball);

		mushroom = new Mushroom(new Vec2(350, height - 200), 64, 64);
		AddChild(mushroom);
		mushroom.rotation = 20;
		mushroom.scale = 2;

	}

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
		// Empty
	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		DoTests();
		new MyGame().Start();					// Create a "MyGame" and start it
	}
}