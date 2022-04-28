using System;
using GXPEngine;
using System.Drawing;

public class MyGame : Game
{
    Mushroom mushroom;
    BlowPlant blowPlant;
    SpellRange spellRange;

    public MyGame() : base(1920, 1080, false, true, 960, 540)
    {
        // Draw some things on a canvas:
        EasyDraw canvas = new EasyDraw(800, 600);
        AddChild(canvas);

        spellRange = new SpellRange(3, 3, width / 2, height / 2);
        AddChild(spellRange);

        mushroom = new Mushroom();
        AddChild(mushroom);

        //blowPlant = new BlowPlant();
        //AddChild(blowPlant);



    }

    void Update()
    {

    }

    static void Main()
    {
        new MyGame().Start();
    }
}