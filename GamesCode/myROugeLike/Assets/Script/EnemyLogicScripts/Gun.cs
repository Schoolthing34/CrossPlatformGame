using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    GameObject BasicBullet;
    [SerializeField]
    GameObject MissilePrefab ;


    private List<GameObject> Bullets = new List<GameObject>();
    public int AmountofBullet;
    public float shootDelayTimer;
    public int BulletSpeed;

    public float CountingTimer = 0;


    public PickupComponant PickupStats;
    //Basic Logic
    private bool CurrentlyShooting = false;
    private bool ShootNow = false;
    private bool ShootingMissile=false;
    private float MissileDelayTimer=0.5f;
    public GameObject Shield;
    private GameObject privaetShield;
    public void SetUpGun(int BulletAmount,float SHotTimer,int BulletsSpeed)
    {
        this.AmountofBullet = BulletAmount; 
        this.shootDelayTimer = SHotTimer;
        this.BulletSpeed = BulletsSpeed;
    }


    
  

    public void Shoot()
    {
        if(!CurrentlyShooting)
        {
            ShootNow = true;
            CurrentlyShooting=true;
           // CountingTimer = 0;
        }
    }
    public void ShootMissile()
    {
        if((!ShootingMissile)&&(PickupStats.MissileCount>0))
        {
            ShootingMissile = true;
        }
    }


    // Update is called once per frame
    void Update()
    {

        if(PickupStats.ShieldOn)
        {
            if (privaetShield == null)
            {
                privaetShield = Instantiate(Shield);
                privaetShield.tag = "PlayerShield";
                privaetShield.layer = 15;
                privaetShield.GetComponent<MakeCircle>().Spawn(this.transform.position, 0.56667f, 1, 1);
            }
            PickupStats.ShieldOn = false;
        }

        if (privaetShield != null)
        {
            if (privaetShield.gameObject.activeSelf)
            {
                privaetShield.transform.position = this.transform.position;

            }
        }
        if (ShootNow)
        {
            



            if (CountingTimer >= shootDelayTimer)
            {
                gameObject.SendMessage("PlayAudio", 1, SendMessageOptions.DontRequireReceiver);
                ShootBullet(1);
                ShootNow = false;
                CountingTimer = 0;
                CurrentlyShooting = false;
            }
        }

        if(ShootingMissile)
        {
            gameObject.SendMessage("PlayAudio", 2, SendMessageOptions.DontRequireReceiver);
            ShootBullet(2);
        }

        CountingTimer += Time.deltaTime;
        //BulletRemval


        if (Bullets.Count > 0)
        {
            for (int i = Bullets.Count - 1; i > -1; i--)
            {
                //Vector3.Distance(this.transform.position ,Bullets[i].gameObject.transform.position)
                if (Bullets[i] == null)
                {
                    Bullets.RemoveAt(i);
                    break;
                }
                else if (Vector3.Distance(this.transform.position, Bullets[i].gameObject.transform.position) > 20)
                {
                    // GameObject* DeadBullet=Bullets[i];

                    Destroy(Bullets[i].gameObject);
                    Bullets.RemoveAt(i);
                }



            }



        }
    }

   void ShootBullet(int BulletType)
    {
        GameObject NewBullet = BasicBullet;

        if(PickupStats.DoubleShot)
        {
            if (BulletType == 1)
            {
                NewBullet = Instantiate(BasicBullet, this.transform.position, this.transform.rotation);
                CountingTimer = 0;
                ShootNow = false;
                CurrentlyShooting = false;
            }

            NewBullet.GetComponent<BasicBulletMovement>().Spawn(new Vector3(this.transform.position.x, this.transform.position.y + 1.1f, this.transform.position.z),
            new Vector3(this.transform.position.x + 1000,
            this.transform.position.y,
            this.transform.position.z),
            10f);
            NewBullet.GetComponent<BulletStat>().Spawn(1, 10);
            NewBullet.transform.rotation = Quaternion.Euler(new Vector3(NewBullet.transform.rotation.x, NewBullet.transform.rotation.y, 180));
            Bullets.Add(NewBullet);

        }




        if (BulletType == 1)
        {
             NewBullet = Instantiate(BasicBullet, this.transform.position, this.transform.rotation);
            CountingTimer = 0;
            ShootNow = false;
            CurrentlyShooting = false;
        }
        else if (BulletType == 2)
        {
            NewBullet = Instantiate(MissilePrefab, this.transform.position, this.transform.rotation);
            ShootingMissile = false;
            PickupStats.MissileCount--;
        }


        NewBullet.GetComponent<BasicBulletMovement>().Spawn(this.transform.position,
            new Vector3(this.transform.position.x + 1000,
            this.transform.position.y,
            this.transform.position.z),
            10f);
        NewBullet.GetComponent<BulletStat>().Spawn(1, 10);
        NewBullet.transform.rotation = Quaternion.Euler(new Vector3(NewBullet.transform.rotation.x, NewBullet.transform.rotation.y, 180));
        Bullets.Add(NewBullet);
       

    }
}
