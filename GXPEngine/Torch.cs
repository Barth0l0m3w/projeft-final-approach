using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using GXPEngine.Core;
using TiledMapParser;

public class Torch : AnimationSprite
{
    private int currentState = NORMAL;
    const int NORMAL = 0;
    const int TURNING = 1;

    private Vec2 position;
    private Vec2 velocity;
    private Vec2 aiming;
    private int angle;
    private float speed = 10f;
    private float bounciness = 0.8f;
    private static Vec2 acceleration = new Vec2(0, 0.4f);
    private Vec2 accelerationOriginal;
    private Collider boxCollider;
    private TorchArrow arrow;
   // private MyGame game;

    public Torch(TiledObject obj = null) : base("TorchSprite.png", 8,1)
    {
        position = new Vec2(obj.X, obj.Y);
        velocity = new Vec2(0, 0);
        //height = (int)obj.Height;
        //width = (int)obj.Width;
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
        
        Console.WriteLine(velocity);
        accelerationOriginal = acceleration;
        // Console.WriteLine(speed + " SPEED VALUE");
        arrow = new TorchArrow(0, 0, angle, this);
        LateAddChild(arrow);
        ((MyGame)game).torchMoving = false;
        ((MyGame)game).mobHit = false;
        ((MyGame)game).isBurning = false;
      //  game = ((MyGame)game);
    }

    private void Move()
    {

        if (((MyGame)game).torchMoving)
        {
            velocity += acceleration;
            position += velocity;

            ReduceAcceleration();
        }
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

                Console.WriteLine("depth: {0}  overshootFactor: {1}", ballDistance, overshootFactor);

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
            if (collisions[i] is TheVoid)
            {
                Console.WriteLine("GAME IS OVER, sorry");
                SceneManager.Instance.LoadLevel(((MyGame)game).CurrentLevel);
            }
            if(collisions[i] is Witch)
            {
                ((MyGame)game).isBurning = true;
                Console.WriteLine("BURN THE BITCH!!!!!");
                LateDestroy();
              //  SceneManager.Instance.LoadLevel("map_prototype_big");
            }
            if(collisions[i] is Mob)
            {
                ((MyGame)game).mobHit = true;
                LateDestroy();
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
        if (colInfo != null)
        {
            Vec2 normal = new Vec2(colInfo.normal.x, colInfo.normal.y);
            velocity.Reflect(normal);

        }

    }

    private void ShootTorch()
    {
        if (((MyGame)game).startTorch == true && !((MyGame)game).torchMoving)
        {
            velocity = aiming * speed;
            ((MyGame)game).torchMoving = true;
            ((MyGame)game).startTorch = false; 
            arrow.LateDestroy();
        }
    }

    private void AnimateCharacter()
    {
        switch (currentState)
        {
            case NORMAL:
                SetCycle(0, 8);
                Animate(0.5f);
                break;
            case TURNING:
                //SetCycle();
                Animate(0.5f);
                break;
        }
    }

    void Update()
    {

        //Alternative();
        //Draw the boxCollider
        AnimateCharacter(); 
        Move();
        CheckCollisions();
        UpdateScreenPosition();
        ShootTorch();
    }
}

