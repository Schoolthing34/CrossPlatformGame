using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1EldritchMoon : BaseEnemy
{
    private EnemyLogicComponant EnemyLogicComponant;
    public MoveOffScreenFromPositionScript Movement;
    public int Speed;

    //Logic
    //2 moves
    //laser and move

    //make randomNumberApear
    //use number for which move we use

    public bool Entrance;
    public bool MoveRunAtPlayer;
    public bool ShootLasers;
    public bool MakeYourChoice;



    public float MoveDuration;



    //Logic underLasers
    public bool ShotLasers;
   public float LaserDelay;
    public GameObject[] Beams;
    public GameObject[] WarningBeam;
    int Dir;
    float DirCounter = 0;

    /// <summary>
    /// Movement states
    /// </summary>
    bool SettingUpMovement = false;
   


    private float Counter = 0;

    private float CoolDownTime = 1;
    private bool OnCooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        EnemyLogicComponant = GameObject.Find("EnemyHeadManager").GetComponent<EnemyLogicComponant>();
        if (EnemyLogicComponant == null)
        {
            Debug.LogError("Cant get the enemylogic componant");

        }
        if (Testing)
        {
            Spawn(new Vector3(1, 1, 0), 0, 0);
        }
    }


    public override void Spawn(Vector3 StartTarget, float Xdirection, float YDirection, int speed = 4, int Heath = 20, int rank = 10)
    {
        if (!Testing)
        { 
                Start();
          }
        this.transform.position=StartTarget;
        base.EnemyHealth = Heath;
        ShootLasers = false;
        MoveRunAtPlayer = false;
        MakeYourChoice = false;
        Entrance = true;
        OnCooldown= false;
        Speed = speed;
        Movement.MoveToSpecificPiont(0,0,Speed);

    }

    // Update is called once per frame
    void Update()
    {
        if(Entrance)
        {
            if(!Movement.move)
            {
                Entrance = false;
                MakeYourChoice = true;
            }
        }



        if (MakeYourChoice)
        {
            int Descision = Random.Range(1, 10);


            if (Descision < 6)
            {
                ShootLasers = true;
                MoveDuration = Random.Range(3.0f,10.0f) ;

            }
            else if (Descision >=6)
            {
                MoveRunAtPlayer = true;
                MoveDuration = Random.Range(3.0f, 15.0f);
            }
            MakeYourChoice = false;
            Counter = 0;
        }



        if(ShootLasers)
        {
            StartShootingLasers();
        }
        else if(MoveRunAtPlayer)
        {
            RunAtPlayers();
        }


        if(OnCooldown)
        {
            Counter += Time.deltaTime;
            if(Counter> CoolDownTime)
            {
                Movement.MoveToSpecificPiont(0,0,Speed);
                Entrance = true;
                OnCooldown = false;
            }
        }
    }


    private void RunAtPlayers()
    { 
    //get player pos
    //go there
    //reeat till over

        if(SettingUpMovement)
        {
            Movement.MoveToSpecificPiont(EnemyLogicComponant.ReturnPlayerPosition().x,EnemyLogicComponant.ReturnPlayerPosition().y,   Speed);
            SettingUpMovement = false;
        }
        else if(!Movement.move)
        {
            SettingUpMovement= true;
            if (Counter > MoveDuration)
            {
                MoveRunAtPlayer = false;

                OnCooldown = true;
                Counter = 0;
            }

        }

        Counter += Time.deltaTime;
        


        }
    private void StartShootingLasers()
    {
        if (!ShotLasers)
        {
            for (int i = 0; i < WarningBeam.Length; i++)
            {
                WarningBeam[i].SetActive(true);

            }
           
          
            Counter += Time.deltaTime;
            if (LaserDelay < Counter)
            {
                Counter = 0;
                ShotLasers = true;
                for (int i = 0; i < WarningBeam.Length; i++)
                {
                    WarningBeam[i].SetActive(false);
                    Beams[i].SetActive(true);
                     Dir = UnityEngine.Random.Range(1,4);
                    DirCounter = 0;

                }



            }

        }
        else if(ShotLasers)
        {
            float RotateDistance = 0.075f;
           if(Dir%2==0)
            {
                transform.Rotate(0, 0, RotateDistance);
            }
           else
            {
                transform.Rotate(0, 0, -RotateDistance);
            }
          //  transform.Rotate(0,0,0.05f);

            Counter += Time.deltaTime;
            DirCounter += Time.deltaTime;
            if(Counter>MoveDuration)
            {
                Counter = 0;
                OnCooldown = true;
                ShotLasers = false;
                ShootLasers = false;

                for (int i = 0; i < WarningBeam.Length; i++)
                {
                   // WarningBeam[i].SetActive(false);
                    Beams[i].SetActive(false);

                }
            }

            if(DirCounter>3)
            {
                DirCounter +=- 3;

                Dir = UnityEngine.Random.Range(1, 4);

            }




        }


    }
}
