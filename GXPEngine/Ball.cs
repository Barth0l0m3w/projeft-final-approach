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
    private float speed = 3f;
    private float bounciness = 0.8f;
    private static Vec2 acceleration = new Vec2(0, 1);
    private Collider boxCollider;
    Vector2 normalBig;

    public Ball(int height, int width, Vec2 position, Vec2 velocity) : base("circle.png")
    {
        this.position = position;
        this.velocity = velocity;
        x = position.x;
        y = position.y;
        this.height = height;
        this.width = width;
        boxCollider = createCollider();
        SetOrigin(width / 2, height / 2);
    }

    private void Move()
    {
        //velocity += acceleration;
        position += velocity;
    }

    private void CheckCollisions()
    {
        float impactY;
        float time;
        float ballDistance;
        Vec2 normal = new Vec2(0, 0);

        GameObject[] collisions = GetCollisions();
        for (int i = 0; i < collisions.Length; i++)
        {
            if (collisions[i] is Mushroom)
            {
                //impactY = collisions[i].y - height;
                //time = (impactY - oldPosition.y) / (position.y - oldPosition.y);
                //position = oldPosition + time * velocity;
                //velocity.y = -bounciness * velocity.y;
                Console.WriteLine(boxCollider.GetCollisionInfo(((Mushroom)collisions[i]).boxCollider));
                time = boxCollider.TimeOfImpact(((Mushroom)collisions[i]).boxCollider, velocity.y, velocity.x, out normalBig);
                velocity = new Vec2(0, 0);
            }
        }
    }

    private void UpdateScreenPosition()
    {
        x = position.x;
        y = position.y;
    }

    void Update()
    {
        oldPosition = position;
        Move();
        CheckCollisions();
        UpdateScreenPosition();
        
    }
}

