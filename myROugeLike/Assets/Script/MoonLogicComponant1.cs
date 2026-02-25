using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoonLogicComponant : MonoBehaviour
{


    public EnemyLogicComponant EnemyLogicComponant;
    public MoveOffScreenFromPositionScript Movement;
    public RotateToPlayer Rotation;
    public GetMovemntArea MovementNumbers;
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
        MovementNumbers = GameObject.Find("Moveable Area").GetComponent<GetMovemntArea>();
        //Spawn(this.transform.position, 4, 0, 1);
    }

    virtual public  void Spawn(Vector3 StartTarget,float Xdirection,float YDirection,float speed=1)
    {
        this.transform.position=StartTarget;
       Movement.MoveTo(Xdirection, YDirection);
        Moving = true;
        rotating = false;
        WaitingToFiring = false;
        Firing = false;
       death= false;
    }

        // Update is called once per frame
      public  virtual void Update()
    {

        //enemy logic move rotate shoot and again
        if(Moving)
        {
            if (Movement.move)
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
            if(SHotDelayTimer<0)
            {
                SHotDelayTimer = ShotDelay;
                WaitingToFiring=false;
                Firing=true;
                ShootLaser();
            }
        }
        else if(Firing)
        {
            if (ExcistantTimer < 0)
            {
                ExcistantTimer = 4;
                Moving = true;
                Firing = false;
                NextMovement();
            }
            else
            {
                ExcistantTimer -= Time.deltaTime;
            }
        }
       




     

        

      


    }


    public void NextMovement()
    {

        float x = Random.Range(-MovementNumbers.x,MovementNumbers.x);
        float y = Random.Range(-MovementNumbers.y, MovementNumbers.y);
        Movement.MoveToSpecificPiont(x,y,0.01f);
        Projectile.SetActive(false);
        ProjectileTrail.SetActive(false);



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
