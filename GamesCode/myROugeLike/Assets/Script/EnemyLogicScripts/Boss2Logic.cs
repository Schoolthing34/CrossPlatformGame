using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem.Android;

public class Boss2Logic : BaseEnemy
{
    public MoveOffScreenFromPositionScript Movement;
    public RotateToPlayer Rotation;
    public EnemyLogicComponant PlayerTracker;
    [SerializeField]
    public Boss2Gun[] Turrents= new Boss2Gun[4];
   public  bool MovingStart;
    public bool Shooting;
    public bool Shielded;
    public bool TurrentsStarted = false;
    int speed;
    float ShieldTimer=5.0f;
    float ShootingTimer=5.8f;
    float Counter = 0;
    bool ShieldaAlive;
    float ShieldCounter;
   //s public GameObject Shield;
    public GameObject SecretShield  ;
   // GameObject[] Turrents;

    // Start is called before the first frame update
    void Start()
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
        PlayerTracker = GameObject.Find("EnemyHeadManager").GetComponent<EnemyLogicComponant>();
        if (PlayerTracker == null)
        {
            Debug.LogError("Cant get the enemylogic componant");

        }

        if (Testing)
        {
            Spawn(this.transform.position,0,0);
        }
    }

    public override void Spawn(Vector3 StartTarget, float Xdirection, float YDirection, int speed = 5, int Heath = 20, int rank = 1)
    {
        if (!Testing)
        { 
        Start();
        }
       this.transform.position = StartTarget;
        Movement.MoveToSpecificPiont(Xdirection,YDirection,speed);
        this.speed = speed;
        base.EnemyHealth = Heath;



        MovingStart = true;
        Shielded = false;
        Shooting = false;
        ShieldaAlive = false;
        SecretShield.GetComponent<MakeCircle>().Spawn(this.transform.position,3.636364f, 2,15);
        SecretShield.SetActive(false);

    }




    private void StartTurrent()
    {
        
            for (int i = 0; i < Turrents.Length; i++)
            {
                Turrents[i].StartGun(1, 5);
            }
        TurrentsStarted = true;
    }
    private void StopTurrent()
    {
        for (int i = 0; i < Turrents.Length; i++)
        {
            Turrents[i].StopGun();
        }
        TurrentsStarted = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(MovingStart)
        {
            if(!Movement.move)
            {



                MakeYourCHoice();
                MovingStart=false;
            }
        }

        if(Shielded)
        {
           
            Counter += Time.deltaTime;







            if (!ShieldaAlive)
            {
                Debug.Log("Hey we not alive");
                ShieldCounter += Time.deltaTime;
                if (ShieldCounter > 5.0f)
                {
                    Debug.Log("Hey we back");
                    ShieldaAlive = true;

                    SecretShield.GetComponent<MakeCircle>().Spawn(this.transform.position, 3.636364f, 1, 15);
                    SecretShield.SetActive(true);
                    // this.gameObject.GetComponent<CircleCollider2D>().isTrigger = true ;

                }
            }


            if (ShieldaAlive)
            {
                if (SecretShield != null)
                {
                    if (!SecretShield.activeSelf)
                    {
                        Debug.Log("Hey we dead");
                        ShieldaAlive = false;
                        ShieldCounter = 0;
                        //this.gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
                    }
                    else
                    {
                        //Debug.Log("Hey we normal day");
                        SecretShield.transform.position = this.transform.position;
                    }
                }

            }

            if (Counter > ShieldTimer)
            {
                Shooting = false;
                MakeYourCHoice();
                Counter = 0;
                SecretShield.SetActive(false);
            }
        }
        else if(Shooting)
        {
            if(!TurrentsStarted)
            {
                StartTurrent();
                TurrentsStarted = true;
            }

            //StartTurrent();
            //this is from google
            Vector3 vectorToTarget = PlayerTracker.ReturnPlayerPosition() - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);



            Counter += Time.deltaTime;


            if(Counter>ShootingTimer)
            {
                Shooting = false;
                StopTurrent();
                MakeYourCHoice() ;
                Counter = 0;
            }
            //this.transform.LookAt(PlayerTracker.ReturnPlayerPosition());

           // this.transform.rotation= Quaternion.Euler(new Vector3(0, 0, this.transform.rotation.z));



        }



    }

    private void MakeYourCHoice()
    {



        int Choice = UnityEngine.Random.Range(1,11);



        if (Choice <= 6)
        {
            Shooting = true;
            Shielded = false;
            SecretShield.SetActive(false);
        }
        else if(Choice>6)
        {
            Shooting = false;
            Shielded = true;
            SecretShield.SetActive(true);
            
        }
    }
}
