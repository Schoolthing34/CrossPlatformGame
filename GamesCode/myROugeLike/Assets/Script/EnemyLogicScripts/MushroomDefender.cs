using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class MushroomDefender : BaseEnemy
{
    public MoveOffScreenFromPositionScript Movement;



    public bool ShieldOn;
    private float ShieldBackTimer;
    public GameObject Shield;
    public GameObject SecretShield;
    // Start is called before the first frame update
    void Start()
    {
        Movement = this.gameObject.GetComponent<MoveOffScreenFromPositionScript>();
        if (Movement == null)
        {
            Debug.LogError("Cant get the Movement componant");

        }




    }


    public override void Spawn(Vector3 StartTarget, float Xdirection, float YDirection, int speed = 5, int Heath = 1, int rank = 1)
    {
        Start();
        this.transform.position = StartTarget;
        
        Movement.MoveTo(Xdirection, 0, speed);
        SecretShield = Instantiate(Shield);
        SecretShield.GetComponent<MakeCircle>().Spawn(this.transform.position,2.0f,1,5);
        SecretShield.SetActive(true);
        ShieldOn = true;
        base.EnemyHealth=Heath;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(!ShieldOn)
        {
            ShieldBackTimer += Time.deltaTime;
            if(ShieldBackTimer>5.0f)
            {
                ShieldOn = true;

                SecretShield.GetComponent<MakeCircle>().Spawn(this.transform.position, 2,1,5);
                SecretShield.SetActive(true);
               // this.gameObject.GetComponent<CircleCollider2D>().isTrigger = true ;
                
            }
        }



        if(ShieldOn)
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

    private void OnDestroy()
    {
        Destroy(SecretShield);
    }
}
