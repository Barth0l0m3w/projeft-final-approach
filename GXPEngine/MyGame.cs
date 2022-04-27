using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;							// System.Drawing contains drawing tools such as Color definitions

public class MyGame : Game
{
    Objects objects;
    public MyGame() : base(800, 600, false)     // Create a window that's 800x600 and NOT fullscreen
    {
        // Draw some things on a canvas:
        EasyDraw canvas = new EasyDraw(800, 600);
        AddChild(canvas);

        objects = new Objects(new Vec2(400, 500));
        AddChild(objects);
    }

    // For every game object, Update is called every frame, by the engine:
    void Update()
    {
        objects.Step();
    }

    static void Main()                          // Main() is the first method that's called when the program is run
    {
        new MyGame().Start();                   // Create a "MyGame" and start it
    }
}