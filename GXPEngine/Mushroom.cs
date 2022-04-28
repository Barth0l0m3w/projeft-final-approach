using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


public class Mushroom : Objects
{

    public Mushroom(): base(new Vec2(400, 500), "circle.png")
    {

    }

    void Update()
    {
        Step();
    }
}

