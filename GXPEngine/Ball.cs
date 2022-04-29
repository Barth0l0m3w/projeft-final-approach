using System;
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
    private float speed = 10f;
    private float bounciness = 0.8f;
    private static Vec2 acceleration = new Vec2(0, 0.4f);
    private Vec2 accelerationOriginal;
    private Collider boxCollider;

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
        Console.WriteLine("X: " + x + " Y: " + y);
        aiming = Vec2.GetUnitVectorDeg(angle);
        Console.WriteLine(aiming.ToString());
        Console.WriteLine(speed);
        velocity = aiming * speed;
        Console.WriteLine(velocity);
        accelerationOriginal = acceleration;
    }

    private void Move()
    {
        
        velocity += acceleration;
        position += velocity;
        
        ReduceAcceleration();
        
        
    }



    private void CheckCollisions()
    {
        float ballDistance;

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

                if (normal.Dot(velocity) < 0)
                {
                    velocity.Reflect(normal, bounciness);
                }
            }
            if (collisions[i] is BlowPlant)
            {
                acceleration = accelerationOriginal * -((BlowPlant)collisions[i]).power;
            }
        }
    }

    private void ReduceAcceleration()
    {
        acceleration = accelerationOriginal;
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
        Console.WriteLine("Acceleration: " + acceleration);
        Console.WriteLine("Velocity: " + velocity);
        Move();
        CheckCollisions();
        UpdateScreenPosition();
        Gizmos.DrawRectangle(0, 0, texture.width, texture.height, this);
    }
}

