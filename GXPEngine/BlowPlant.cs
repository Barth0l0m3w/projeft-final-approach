using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;


public class BlowPlant : Objects
{

    public BlowPlant(TiledObject obj = null) : base("plant.png")
    {
        
        height = (int)obj.Height;
        width = (int)obj.Width;
        SetOrigin(width / 2, height / 2);
        Console.WriteLine(obj.X + ", "+obj.Y);
        Position = new Vec2(obj.X, obj.Y);
        Console.WriteLine("flower position: "+ Position + " " +x + " " +y);
        
    }

    void Update()
    {
        Step();
    }
}

