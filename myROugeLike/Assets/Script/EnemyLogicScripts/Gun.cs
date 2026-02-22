using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    GameObject BasicBullet;


    private List<GameObject> Bullets = new List<GameObject>();
    public int AmountofBullet;
    public float shootDelayTimer;
    public int BulletSpeed;

    public float CountingTimer = 0;

    //Basic Logic
    private bool CurrentlyShooting = false;
    private bool ShootNow = false;

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
        


    // Update is called once per frame
    void Update()
    {
        if (ShootNow)
        {
            



            if (CountingTimer >= shootDelayTimer)
            {

                GameObject NewBullet = Instantiate(BasicBullet,this.transform.position,this.transform.rotation);
                NewBullet.GetComponent<BasicBulletMovement>().Spawn(this.transform.position,
                    new Vector3(this.transform.position.x + 1000,
                    this.transform.position.y,
                    this.transform.position.z),
                    10f);
                NewBullet.GetComponent<BulletStat>().Spawn(1, 10);
                Bullets.Add(NewBullet);
                CountingTimer = 0;
                ShootNow = false;
                CurrentlyShooting = false;
            }
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
}
