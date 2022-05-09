using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using GXPEngine.Core;
using TiledMapParser;


internal class TorchArrow : Sprite
{
    private float angle;
    Torch torchSuperior;
    public TorchArrow(float x, float y, float angle, Torch torch) : base("arrow.png")
    {
        this.angle = angle;
        this.x = x;
        this.y = y;
        torchSuperior = torch;
        SetOrigin(x-torchSuperior.width/2, height/2);
        rotation = angle-20;
        Console.WriteLine("ARROW" + x + " " + y);
    }

    void Update()
    {
        //rotation++;
    }
}

