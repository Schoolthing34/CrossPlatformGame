using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.Rendering;
using UnityEngine;

public class FrogShammonLogicScript : BaseEnemy
{



    const float ToadY = -4.44f;
    float speed;
    public int MaxShots = 6;
    public int minShots = 1;
    float MinX=6;
    float MaxX=-6;


    bool SpawningState;
    //here we spanw and immortal
    //below two states resting is the inbetween of shooting
    bool Resting;

    bool SetUpLightningshots;
    bool FiredLightning;
    bool Shooting;

    public GameObject Shield1;
    public float RestTimer;
    public float ShootingDelayTimer;
    int DescidingHowMany;
    private float TimerCounter = 0;

    public GameObject LightningPrefab;
    private GameObject[] Lightning;
    // Start is called before the first frame update
    void Start()
    {
        base.SpawnArea=Camera.main.GetComponent<GetMovemntArea>();
        MinX = SpawnArea.ReturnBottomLeft().x;
        MaxX = SpawnArea.ReturnTopRight().x;
        float range=MaxX-MinX;
        range = range / 5;
        MaxX -= range;
        MinX += range;

        if (base.Testing)
        {
            Spawn(new Vector3(0,0,0),0,0);
        }
    }


    public override void Spawn(Vector3 StartTarget,  float Xdirection, float YDirection, int speed = 1, int Heath = 3, int rank = 1)
    {
        if(!Testing)
        {
            Start();
        }


        Lightning = new GameObject[MaxShots];
        for(int i=0;i<Lightning.Length;i++)
        {
            Lightning[i] = Instantiate(LightningPrefab);
            Lightning[i].transform.GetChild(0).gameObject.SetActive(false);
            Lightning[i].transform.GetChild(1).gameObject.SetActive(false);
        }
        float x = Random.Range(MinX, MaxX);
        this.transform.position = new Vector3(x,ToadY,0);
        base.EnemyHealth = Heath;
        
        SpawningState = true;
        Shooting = false;
         Resting=false;

         SetUpLightningshots = false;
         FiredLightning = false;
         Shooting = false;

        StartRotating();


    }


    public void StartRotating()
    {
        Shield1.GetComponent<ShieldRotating>().StartRotating();
    }

   public  void  Spawn()
    {
        if (!Testing)
        {
            Start();
        }


        //this.transform.position = new Vector3(StartTarget.x, ToadY, 0);
        base.EnemyHealth = 3;
        speed = 1;

        //Spawning a frog
        float XChoice = Random.Range(MaxX, MinX);

        this.transform.position = new Vector3(XChoice, ToadY, 0);
        SpawningState = true;
        Shooting = false;
        Resting = false;

        SetUpLightningshots = false;
        FiredLightning = false;
        Shooting = false;

        StartRotating();

    }


    // Update is called once per frame
    void Update()
    {
        if(SpawningState)
        {

            if(!Shield1.GetComponent<ShieldRotating>().Rotating)
            {
                Resting = true;
                this.gameObject.GetComponent<Collider2D>().enabled = true;
            }


        }


        if(Resting)
        {
            TimerCounter += Time.deltaTime;



            if(TimerCounter>=RestTimer)
            {


                SetUpLightningShots();
                Resting = false;
                Shooting = true;
                TimerCounter = 0;
            }


        }



        if (Shooting)
        {
            TimerCounter += Time.deltaTime;



            if (TimerCounter >= ShootingDelayTimer)
            {
                //this shoots the lightning
                UnlimitedPower();

                //Resting = true;
                Shooting = false;
                FiredLightning = true;
                TimerCounter = 0;
            }
        }

        if(FiredLightning)
        {

            TimerCounter += Time.deltaTime;



            if (TimerCounter >= ShootingDelayTimer)
            {

                Resting = true;
                FiredLightning = false;
                TimerCounter = 0;

                TurnOffLightning();
            }
        }


        
    }

    private void OnDestroy()
    {
        for(int i=0;i<Lightning.Length;i++)
        {
            if (Lightning[i].gameObject != null)
            {
                Lightning[i].transform.GetChild(1).gameObject.SetActive(false);
                Lightning[i].transform.GetChild(0).gameObject.SetActive(false);
                Destroy(Lightning[i]);
            }
        }
        Destroy(this.gameObject);
    }
   
    private void TurnOffLightning()
    {

        for (int i = 0; i < Lightning.Length; i++)
        {
            //float x = Random.Range(MinX, MaxX);


            //Lightning[i].gameObject.transform.position = new Vector3(x, Lightning[i].gameObject.transform.position.y, 0);
            Lightning[i].transform.GetChild(1).gameObject.SetActive(false);
            // Lightning[i].SetActive(true);

        }


    }
    private void SetUpLightningShots()
    {
         DescidingHowMany = Random.Range(minShots, MaxShots);



        for(int i=0;i<DescidingHowMany;i++)
        {
            float x = Random.Range(MinX,MaxX);


            Lightning[i].gameObject.transform.position = new Vector3(x, Lightning[i].gameObject.transform.position.y, 0);
            Lightning[i].transform.GetChild(0).gameObject.SetActive(true);
           // Lightning[i].SetActive(true);

        }
    }

    private void UnlimitedPower()
    {
        for (int i = 0; i < DescidingHowMany; i++)
        {
           // float x = Random.Range(MinX, MaxX);


            //Lightning[i].gameObject.transform.position += new Vector3(x, 0, 0);
            //Lightning[i].SetActive(false);
            Lightning[i].transform.GetChild(0).gameObject.SetActive(false);
            Lightning[i].transform.GetChild(1).gameObject.SetActive(true);

        }
       // Debug.Log("Hey emperoe");
    }
}
