using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;


public class BlowPlant : Objects
{
   public float power = 0f;
    public bool inSpellRange;

    public BlowPlant(TiledObject obj = null) : base("Blow Plant.png")
    { 
        SetOrigin(width / 2, height / 2);
        Position = new Vec2(obj.X, obj.Y);
        power = obj.GetFloatProperty("power", 0f);
        Console.WriteLine(power);
    }

    void Update()
    {
        Step();
    }
}

