using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;


internal class DownCloud : Objects
{
    public float power = 0f;
    public DownCloud(TiledObject obj = null) : base("cloud.png")
    {
        SetOrigin(width/2, height/2);
        Position = new Vec2(obj.X, obj.Y);
        power = obj.GetFloatProperty("power", 0f);

    }

    void Update()
    {
        Step();
    }
}

