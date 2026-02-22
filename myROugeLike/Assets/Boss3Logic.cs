using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Logic : BaseEnemy
{

    bool Alive;

    bool ShieldOn;
    float ShieldBackTimer;
    bool timerStarted=false;
    public GameObject ShieldPrefab;
    GameObject SecretShield;
    GameObject SpeechManager;
    float Timer = 30.0f;
    // Start is called before the first frame update

    public override void Spawn(Vector3 StartTarget, float Xdirection, float YDirection, int speed = 1, int Heath = 40, int rank = 200)
    {
        if (!Testing)
        {
            Start();
        }
        base.EnemyHealth = Heath;


        this.transform.position = new Vector3(4.53000021f, 1.45000005f, -0.207980454f);
        Alive = true;
        //UnityEditor.TransformWorl//dPlacementJSON:{ "position":{ "x":7.439999580383301,"y":3.1500000953674318,"z":0.0},"rotation":{ "x":0.0,"y":0.0,"z":-0.4066029191017151,"w":0.9136050343513489},"scale":{ "x":1.0,"y":1.0,"z":1.0} }
        SecretShield = Instantiate(ShieldPrefab);
    }
    void Start()
    {
        
        SpeechManager = GameObject.Find("SpeechManager");
        if (base.Testing)
        {
            Spawn(new Vector3(0, 0, 0), 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Alive)
        {

            /* if((base.EnemyHealth<=40)&&(base.EnemyHealth>20))
             {
                 //lasers

             }
             else if ((base.EnemyHealth <= 20) && (base.EnemyHealth > 20))
             {
                 //spawn some enemies

             }
             else if (base.EnemyHealth <= 40) 
             {
                 //just shield




             }*/
            //hey descided not enough time for this so just gonna do shield idea
            if(timerStarted)
            {
                Timer -= Time.deltaTime;
                string temp = " CountDown" + Timer;
                SpeechManager.GetComponent<DialogueManager>().UpdateRightText(temp);
            }
            DialogueBox();

            ShieldStuff();

            //here lets do voicelines

           


        }
    }

    public void DialogueBox()
    {

        if((base.EnemyHealth<41)&&(base.EnemyHealth>35))
        {
            timerStarted = true;
            SpeechManager.GetComponent<DialogueManager>().UpdateMiddleText("I have started a timer just give up and\n leave You will not win ");
        }


    }
    public void ShieldStuff()
    {

        if (!ShieldOn)
        {
            ShieldBackTimer += Time.deltaTime;
            if (ShieldBackTimer > 5.0f)
            {
                ShieldOn = true;

                SecretShield.GetComponent<MakeCircle>().Spawn(this.transform.position, 2, 1, 5);
                SecretShield.SetActive(true);
                // this.gameObject.GetComponent<CircleCollider2D>().isTrigger = true ;

            }
        }



        if (ShieldOn)
        {
            if (SecretShield != null)
            {
                if (!SecretShield.activeSelf)
                {
                    ShieldOn = false;
                    ShieldBackTimer = 0;
                    //this.gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
                }
                else
                {
                    SecretShield.transform.position = this.transform.position;
                }
            }

        }




    }
}
