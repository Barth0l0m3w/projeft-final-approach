using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


public class BlowPlant : Objects
{

    public BlowPlant() : base(new Vec2(300, 300), "triangle.png")
    {

    }

    void Update()
    {
        Step();
    }
}

