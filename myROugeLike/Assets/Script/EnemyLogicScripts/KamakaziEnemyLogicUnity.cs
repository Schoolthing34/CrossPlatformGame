using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using Random = UnityEngine.Random;

public class KamakaziEnemyLogicUnity : BaseEnemy
{

    public EnemyLogicComponant EnemyLogicComponant;
    public MoveOffScreenFromPositionScript Movement;
    public RotateToPlayer Rotation;
    public GetMovemntArea MovementNumbers;
    public bool aiming;
    public bool moving;
    public bool dying;
    public float speed;
    public float offset;
    //Movement variables
    public bool IsNorth;
    public bool IsSouth;
    public bool IsEast;
    public bool IsWest;
    public int LeftPlayerVissionrea = 0;
    override public  void Spawn(Vector3 StartTarget, float Xdirection, float YDirection, int speed = 1,int Health=1,int Rank=1)
    {
        Start();
        this.transform.position = StartTarget;
        aiming = false;
        moving = true;
        dying = false;
        EnemyHealth = Health;
        Movement.MoveTo(1,0,speed);
        IsEast = true;
        this.Ranking = Rank;
        
    }

    public void Start()
    {
        Movement = this.gameObject.GetComponent<MoveOffScreenFromPositionScript>();
        if (Movement == null)
        {
            Debug.LogError("Cant get the Movement componant");

        }

        Rotation = this.gameObject.GetComponent<RotateToPlayer>();
        if (Rotation == null)
        {
            Debug.LogError("Cant get the Rotation componant");

        }
        MovementNumbers = GameObject.Find("Moveable Area").GetComponent<GetMovemntArea>();
       // Spawn(this.transform.position, 4, 0, 1);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
      //  if(collision.gameObject.tag== "InvisibleWalls")
      //  {
            //Debug.Log("Left insiWall;");
           // LeftPlayerVissionrea++;
      //  }
    }
    // Start is called before the first frame update
  

    // Update is called once per frame
    public  void Update()
    {
        if (moving)
        {
            if (!Movement.move)
            {
                moving = false;
                aiming = true;
                Rotation.StartRotation(offset, 3);


            }
        }

            if(aiming)
            {
                if(!Rotation.StartRotating)
                {
                    aiming = false;

                    //Movement.MoveTo(100, 0, speed);
                    dying = true;
                }
            }

            if(dying)
            {

            transform.Translate(-transform.right * speed * Time.deltaTime, Space.World);
            /*
            if (IsNorth)
            {
                transform.Translate(-transform.up * speed * Time.deltaTime, Space.World);
            }
            else if(IsSouth)
            {
                transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
            }
            else if(IsWest)
            {
                transform.Translate(-transform.right * speed * Time.deltaTime, Space.World);
            }
            else if (IsEast)
            {
               
                transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
            }
        */
            

            if (this.transform.position.x < -15)
            {
                LeftPlayerVissionrea++;
            }
            if (this.transform.position.x > 15)
            {
                LeftPlayerVissionrea++;
            }

            if (this.transform.position.y > 10)
            {
                LeftPlayerVissionrea++;
            }
            if (this.transform.position.y < -10)
            {
                LeftPlayerVissionrea++;
            }

            if(LeftPlayerVissionrea==2)
            {
                Debug.Log("We respawning");
                ResetPosition();
                dying = false;
                moving = true;
            }

        }



        
    }

    private void ResetPosition()
    {
        LeftPlayerVissionrea = 0;
        int CardinaalDirection = Random.Range(1,4);

        //foat x,y;
        float x=0, y=0;

        IsNorth = false;
        IsSouth = false;
        IsEast = false;
        IsWest = false;

        switch(CardinaalDirection)
        {
            case 1:
                //east
                x = -9;
                y=Random.Range(-4,4);
                IsEast = true;
                break;
            case 2:
                //west
                x = 9;
                y = Random.Range(-4, 4);
                IsWest = true;
                break;
            case 3:
                //North
                IsNorth = true;
                x = Random.Range(-6,6);
                y = 6;
                break;
            case 4:
                //Souht
                IsSouth = true;
                x = Random.Range(-6, 6);
                y = -6;
                break;



        }

        Debug.Log("We respawning direction N " +IsNorth+" s "+IsSouth+" e "+IsEast+" w "+IsWest);
        this.transform.position= new Vector3(x, y, 0);

        if (IsNorth)
        {
            Movement.MoveTo(0, -1, speed);
        }
        else if (IsSouth)
        {
            Movement.MoveTo(0, 1, speed);
        }
        else if (IsWest)
        {
            Movement.MoveTo(-1, 0, speed);
        }
        else if (IsEast)
        {
            Movement.MoveTo(1, 0, speed);
        }
        ///if spawned north
        /////head south
        ///



    }


    //okay so yeah lets them go forever
}
