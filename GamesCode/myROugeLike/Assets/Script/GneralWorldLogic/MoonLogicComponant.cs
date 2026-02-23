using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoonLogicComponant : BaseEnemy
{

    
    //public EnemyLogicComponant EnemyLogicComponant;
    public MoveOffScreenFromPositionScript Movement;
    public RotateToPlayer Rotation;
  //  public GetMovemntArea MovementNumbers;
    // Start is called before the first frame update
    public float Offset;
    public float ShotTimer;
    public float SHotDelayTimer;
    public float ExcistantTimer;
    public bool ShotFired;
    public bool death;
    public bool SHootingTime;

    private float ShotDelay;
    //Log gates
    public bool Moving;
    public bool rotating;
    public bool WaitingToFiring;
    public bool Firing;
    
    //this enemy have one goal rotate towards the player shoot and then leave

    //Enemy Projecyiles
    public GameObject ProjectileTrail;
    public GameObject Projectile;
   virtual public void Start()
    {
        //Debug.Log("Hey called");
        ShotDelay = SHotDelayTimer;
        
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
       // MovementNumbers = GameObject.Find("Moveable Area").GetComponent<GetMovemntArea>();
        //Spawn(this.transform.position, 4, 0, 1);
    }

    override public void Spawn(Vector3 StartTarget, float Xdirection, float YDirection, int speed = 1, int Heath = 2, int rank = 1)
    {
        Start();
        this.transform.position = StartTarget;
        Movement.MoveTo(Xdirection, YDirection);
        Moving = true;
        rotating = false;
        WaitingToFiring = false;
        Firing = false;
        death = false;
        base.EnemyHealth = Heath;
        this.Ranking = rank;
    }

        // Update is called once per frame
      public  virtual void Update()
    {

        //enemy logic move rotate shoot and again
        if(Moving)
        {
            if (!Movement.move)
            {
                Moving = false;
                Rotation.StartRotation(Offset, ShotTimer);
                rotating = true;
            }
        }
        else if(rotating)
        {
            if (!Rotation.StartRotating)
            {
                rotating = false;
                WaitingToFiring = true;
                
            }
        }
        else if(WaitingToFiring)
        {
            SHotDelayTimer-= Time.deltaTime;
            ProjectileTrail.SetActive(true);
            if (SHotDelayTimer<0)
            {
                SHotDelayTimer = ShotDelay;
                WaitingToFiring=false;
                Firing=true;
                //ShootLaser();
            }
        }
        else if(Firing)
        {
            Projectile.SetActive(true);
            ProjectileTrail.SetActive(false);
            if (ExcistantTimer < 0)
            {
                
                ExcistantTimer = 4;
                rotating = true;
                Firing = false;
                ShotTimer = Random.Range(3.0f,7.0f);
                Rotation.StartRotation(Offset, ShotTimer);
                //NextMovement();
                Projectile.SetActive(false);
                ProjectileTrail.SetActive(false);
            }
            else
            {
                ExcistantTimer -= Time.deltaTime;
            }
        }
       




     

        

      


    }


    
       // Debug.Log("Hey2");

    
    private void ShootLaser()
    {
        //box that expands on eway nd collision
        ProjectileTrail.SetActive(true);

        if(SHotDelayTimer<=0)
        {
            Projectile.SetActive(true);
            ProjectileTrail.SetActive(false);
            ShotFired = true;
            Moving = true;
           // StartCoroutine("Death", 4);
        }

    }

    
}
