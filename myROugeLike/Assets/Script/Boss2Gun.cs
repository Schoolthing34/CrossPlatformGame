using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Boss2Gun : MonoBehaviour
{
    [SerializeField]
    GameObject BasicBullet;


    private List<GameObject> Bullets = new List<GameObject>();

    public float shootDelayTimer;
    public int BulletSpeed;

    public float CountingTimer = 0;
    public bool Firing;

    public GameObject OurPos;
    public GameObject BossPos;

    private void Start()
    {
       // StartGun(1,5);
    }
    public  void SetUpGun( float SHotTimer, int BulletsSpeed)
    {
       
        this.shootDelayTimer = SHotTimer;
        this.BulletSpeed = BulletsSpeed;
    }


    public  void StartGun(float SHotTimer, int BulletsSpeed)
    {
        this.shootDelayTimer = SHotTimer;
        this.BulletSpeed = BulletsSpeed;
        Firing = true;
    }

    public void StopGun()
    {
        Firing = false;
    }


    void Update()
    {

        if (Firing)
        {


           
            if (CountingTimer >= shootDelayTimer)
            {

                GameObject NewBullet = Instantiate(BasicBullet,this.transform.position,this.transform.rotation);
                Vector3 dave = OurPos.transform.position;
                //dave = dave * ;

               // NewBullet.GetComponent<BulletMovementEnemy>().Spawn(10,
                 // dave);
                NewBullet.GetComponent<BulletStat>().Spawn(1, 10);
                Bullets.Add(NewBullet);
                CountingTimer = 0;
               // Debug.Log("dave is "+this.gameObject.name+" "+dave+" "+this.transform.position+" "+BossPos.transform.position);

            }

            CountingTimer += Time.deltaTime;
            //BulletRemval


            
        }
        if (Bullets.Count > 0)
        {
            for (int i = Bullets.Count - 1; i >=0; i--)
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
                else
                {
                    Bullets[i].GetComponent<Rigidbody2D>().velocity = Bullets[i].transform.right * BulletSpeed;

                }
                //  rb = GetComponent<Rigidbody>();
                //  rb.velocity = transform.forward * speed;

                //   Bullets[i].GetComponent<Rigidbody2D>().MovePosition(Bullets[i].GetComponent<Rigidbody2D>().position + (BulletSpeed * Time.deltaTime * transform.forward);

                // .velocity = transform.forward * BulletSpeed * Time.deltaTime;
                //rb.MovePosition(rb.position + transform.forward * speed * Time.fixedDeltaTime);

            }



        }


    }
}
