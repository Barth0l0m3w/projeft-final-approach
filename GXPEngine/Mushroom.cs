using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using GXPEngine.Core;

class Mushroom : Sprite
{
    public Vec2 position;
    public Collider boxCollider;

    public Mushroom(Vec2 position, int width, int height) : base("colors.png")
    {
        this.position = position;
        boxCollider = createCollider();
        this.width = width;
        this.height = height;
        SetOrigin(this.width/2,this.height/2);


        x = position.x;
        y = position.y;

        //rotation = 45;
    }
}

