using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using GXPEngine.Core;

public class Ball : Sprite
{
    private Vec2 position;
    private Vec2 velocity;
    private Vec2 oldPosition;
    private Vec2 oldVelocity;
    private float speed = 3f;
    private float bounciness = 0.8f;
    private static Vec2 acceleration = new Vec2(0, 0.2f);
    private Collider boxCollider;
    Vector2 normalBig;

    public Ball(int radius, Vec2 position, Vec2 velocity) : base("circle.png")
    {
        this.position = position;
        this.velocity = velocity;
        x = position.x;
        y = position.y;
        height = radius*2;
        width = radius*2;
        boxCollider = createCollider();
        SetOrigin(width / 2, height / 2);
        oldVelocity = velocity;
        Console.WriteLine("X: " + x + " Y: " + y);
    }

    private void Move()
    {
      //  velocity += acceleration;
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

                ballDistance -= 1 - overshootFactor;

                position += normal * (ballDistance);

                if (normal.Dot(velocity) < 0)
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
        oldPosition = position;
        oldVelocity = velocity;

        //Alternative();

        Gizmos.DrawRectangle(0, 0, width, height, this);
        Move();
        CheckCollisions();
        UpdateScreenPosition();
        
    }
}

