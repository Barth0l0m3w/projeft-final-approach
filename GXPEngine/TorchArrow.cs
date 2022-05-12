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
    Sprite arrow2 = new Sprite("arrow2.png");
    public TorchArrow(float x, float y, float angle, Torch torch) : base("arrow.png")
    {
        this.angle = angle;
        this.x = x;
        this.y = y;
        torchSuperior = torch;
        SetOrigin(x-torchSuperior.width/2, height/2);
        rotation = angle-20;
        Console.WriteLine("ARROW" + x + " " + y);
        if (angle < 0)
        {
            alpha = 0;
            arrow2.SetOrigin(x - torchSuperior.width / 2, height / 2);
            AddChild(arrow2);
        }
    }

    void Update()
    {
        //rotation++;
    }
}

