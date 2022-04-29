using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;


public class BlowPlant : Objects
{

    public BlowPlant(TiledObject obj = null) : base("triangle.png")
    {

    }

    void Update()
    {
        Step();
        Console.WriteLine(Position);
    }
}

