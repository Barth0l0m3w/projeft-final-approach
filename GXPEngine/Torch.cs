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
    private static SoundChannel soundChannel1 = new SoundChannel(1);
    private static Sound hitMob = new Sound("witch_victory_noises.wav");
    private static Sound gameLost = new Sound("witch_defeat_noises.wav");
    

    private int currentState = NORMAL;
    private const int NORMAL = 0;
    const int TURNING = 1;

    private Vec2 position;
    private Vec2 velocity;
    private Vec2 aiming;
    private int angle;
    private float speed = 0;
    private float bounciness = 0.8f;
    private static Vec2 acceleration;
    private Vec2 accelerationOriginal;
    private Collider boxCollider;

    private TorchArrow arrow;
    TiledObject obj;
    bool shootTorch;
    //private MyGame game;

    public Torch(TiledObject obj = null) : base("TorchSprite.png", 8, 1)
    {
        shootTorch = ((MyGame)game).startTorch;
        this.obj = obj;
        acceleration = acceleration = new Vec2(0, 0.4f);
        //SetOrigin(width / 2, height / 2);
        velocity = new Vec2(0, 0);
        //height = (int)obj.Height;
        //width = (int)obj.Width;
        angle = obj.GetIntProperty("angle", 0);
        speed = obj.GetFloatProperty("speed", 0f);
        SetFrame(0);
       // x = obj.X;// + width / 2;
       // y = obj.Y;// + height / 2;
        position = new Vec2(obj.X+width/2, obj.Y+width/2);
        Console.WriteLine("Torch width: " + width + ":" + height);
        Console.WriteLine("Torch in tiled width: " + obj.Width + ":" + obj.Height);
        //x = position.x;
        // y = position.y;
        boxCollider = createCollider();
        // rotation = angle;
        //scale = 2;
        // obj.Rotation = angle;
        Console.WriteLine("Torch START: " + x + " : " + y);
        Console.WriteLine("Torch END: " + x + width + " : " + y + height);
        Console.WriteLine("Torch PX: " + position.x + " PY: " + position.y);
        Console.WriteLine("Torch PX: " + position.x + width + " PY: " + position.y + height);
        Console.WriteLine("Torch Object START: " + obj.X + " : " + obj.Y);
        Console.WriteLine("Torch Object START: " + obj.X + obj.Width + " : " + obj.Y + obj.Height);
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
        ((MyGame)game).voidTouched = false;
        ((MyGame)game).startTorch = false;
        //  game = ((MyGame)game);
        //UpdateScreenPosition();
    }

    private void Move()
    {

        if (((MyGame)game).torchMoving)
        {
            velocity += acceleration;
            position += velocity;

            ReduceAcceleration();
            UpdateScreenPosition();
        }
    }

    private void CheckCollisions()
    {
        float ballDistance;
        if (((MyGame)game).torchMoving)
        {
            GameObject[] collisions = GetCollisions();
            for (int i = 0; i < collisions.Length; i++)
            {
                if (collisions[i] is Mushroom mushroom)
                {

                    // TODO: use this:
                    Collision colInfo = boxCollider.GetCollisionInfo(mushroom.boxCollider);
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
                if (collisions[i] is BlowPlant plant)
                {
                    if (plant.inSpellRange)
                    {
                        acceleration = accelerationOriginal * -plant.power;
                    }
                    
                }
                if (collisions[i] is DownCloud)
                {
                    acceleration = accelerationOriginal * ((DownCloud)collisions[i]).power;
                }
                if (collisions[i] is TheVoid)
                {
                    soundChannel1 = gameLost.Play();
                    soundChannel1.Volume = 0.2f;

                    Console.WriteLine("GAME IS OVER, sorry");
                    if (MyGame.instance.isBurning)
                    {
                        SceneManager.Instance.LoadLevel(((MyGame)game).CurrentLevel);
                    }
                    else
                    {
                        ((MyGame)game).voidTouched = true;
                       
                    }

                     ((MyGame)game).startTorch = false;
                }
                if (collisions[i] is Witch)
                {
                    ((MyGame)game).isBurning = true;
                    Console.WriteLine("BURN THE BITCH!!!!!");
                    ((MyGame)game).startTorch = false;
                    LateDestroy();
                    //  SceneManager.Instance.LoadLevel("map_prototype_big");
                }
                if (collisions[i] is Mob)
                {
                    soundChannel1 = hitMob.Play();
                    ((MyGame)game).mobHit = true;
                    ((MyGame)game).startTorch = false;
                    LateDestroy();
                }
                if(collisions[i] is Collectable)
                {
                    ((MyGame)game).collectibleGrabbed = true;
                }
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
        shootTorch = ((MyGame)game).startTorch;
        //Console.WriteLine("ShootTorch: " + ((MyGame)game).startTorch);
        if (shootTorch == true && !((MyGame)game).torchMoving)
        {
            position.SetXY(x, y);
            Console.WriteLine("Torch shot");
            velocity = aiming * speed;
            ((MyGame)game).torchMoving = true;
            ((MyGame)game).startTorch = false;
            Console.WriteLine(((MyGame)game).startTorch);
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
        //Gizmos.DrawRectangle(0, 0,width/scaleX, height/scaleY, this);
        //Gizmos.DrawRectangle(0, 0, obj.Width, obj.Height, this);
        AnimateCharacter();
        Move();
        CheckCollisions();
       // Console.WriteLine(((MyGame)game).startTorch);   
        ShootTorch();
    }
}

