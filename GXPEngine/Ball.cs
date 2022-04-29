﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using GXPEngine.Core;
using TiledMapParser;

public class Ball : Sprite
{
    private Vec2 position;
    private Vec2 velocity;
    private Vec2 aiming;
    private int angle;
    private float speed = 3f;
    private float bounciness = 0.8f;
    private static Vec2 acceleration = new Vec2(0, 0.12f);
    private Collider boxCollider;
    Vector2 normalBig;

    public Ball(TiledObject obj = null) : base("Placeholder_size_and_colors_test.png")
    {
        position = new Vec2(obj.X, obj.Y);
        velocity = new Vec2(0,0);
        height = (int)obj.Height;
        width = (int)obj.Width;
        angle = obj.GetIntProperty("angle", 0);
        speed = obj.GetFloatProperty("speed", 0f);
        SetOrigin(width / 2, height / 2);
        x = position.x;
        y = position.y;
        boxCollider = createCollider();
       // rotation = angle;
        //scale = 2;
       // obj.Rotation = angle;
        Console.WriteLine("X: " + x + " Y: " + y);
        aiming = Vec2.GetUnitVectorDeg(angle);
        Console.WriteLine(aiming.ToString());
        Console.WriteLine(speed);
        velocity = aiming * speed;
        Console.WriteLine(velocity);
    }

    private void Move()
    {
        velocity += acceleration;
        position += velocity;
    }



    private void CheckCollisions()
    {
        float impactY;
        float time;
        float ballDistance;
        Vec2 point = new Vec2(0, 0);

        GameObject[] collisions = GetCollisions();
        for (int i = 0; i < collisions.Length; i++)
        {
            if (collisions[i] is Mushroom)
            {
                // TODO: use this:
                Collision colInfo = boxCollider.GetCollisionInfo(((Mushroom)collisions[i]).boxCollider);
               // Console.WriteLine(boxCollider.GetCollisionInfo(((Mushroom)collisions[i]).boxCollider).penetrationDepth);
                ballDistance = colInfo.penetrationDepth;

                Vec2 normal = new Vec2(colInfo.normal.x, colInfo.normal.y);

                Vec2 normalCopy = normal;
                normalCopy.WeirdNormalize();
                float overshootFactor = normalCopy.Length();

                Console.WriteLine("depth: {0}  overshootFactor: {1}",ballDistance,overshootFactor);

               ballDistance /= overshootFactor;

                Console.WriteLine("depth: {0}  overshootFactor: {1}", ballDistance, overshootFactor);


                position += normal * ballDistance;

                if (normal.Dot(velocity) < 0) //&& ballDistance >= (1-overshootFactor))
                {
                    velocity.Reflect(normal, bounciness); // new Vec2(normalBig.x, normalBig.y));
                }
            }
        }
    }

    private void UpdateScreenPosition()
    {
        x = position.x;
        y = position.y;
    }

    void Alternative()
    {
        velocity += acceleration;
        Collision colInfo = MoveUntilCollision(velocity.x, velocity.y);
        if (colInfo!=null)
        {
            Vec2 normal = new Vec2(colInfo.normal.x, colInfo.normal.y);
            velocity.Reflect(normal);

        }

    }

    void Update()
    {
        
        //Alternative();
        //Draw the boxCollider
        
        Move();
        CheckCollisions();
        UpdateScreenPosition();
        Gizmos.DrawRectangle(0, 0, texture.width, texture.height, this);
    }
}
