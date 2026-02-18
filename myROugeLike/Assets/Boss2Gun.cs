using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Gun : MonoBehaviour
{
    [SerializeField]
    GameObject BasicBullet;


    private List<GameObject> Bullets = new List<GameObject>();

    public float shootDelayTimer;
    public int BulletSpeed;

    public float CountingTimer = 0;
    public bool Firing;

    private void Start()
    {
        SetUpGun(1,5);
    }
    public virtual void SetUpGun( float SHotTimer, int BulletsSpeed)
    {
       
        this.shootDelayTimer = SHotTimer;
        this.BulletSpeed = BulletsSpeed;
    }


    public virtual void StartGun(float SHotTimer, int BulletsSpeed)
    {
        this.shootDelayTimer = SHotTimer;
        this.BulletSpeed = BulletsSpeed;
        Firing = true;
    }


    void Update()
    {

        if (Firing)
        {


            Debug.Log("Hey");

            if (CountingTimer >= shootDelayTimer)
            {

                GameObject NewBullet = Instantiate(BasicBullet, this.transform.position, this.transform.rotation);


                // NewBullet.GetComponent<BasicBulletMovement>().Spawn(this.transform.position,
                //  new Vector3(this.transform.position.x + 1000,
                //// this.transform.position.y,
                // this.transform.position.z),
                // 10f);
                NewBullet.GetComponent<BulletStat>().Spawn(1, 10);
                Bullets.Add(NewBullet);
                CountingTimer = 0;

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
                    //  rb = GetComponent<Rigidbody>();
                    //  rb.velocity = transform.forward * speed;

                 //   Bullets[i].GetComponent<Rigidbody2D>().MovePosition(Bullets[i].GetComponent<Rigidbody2D>().position + (BulletSpeed * Time.deltaTime * transform.forward);
                    Bullets[i].GetComponent<Rigidbody2D>().velocity = -transform.right * BulletSpeed;

                    // .velocity = transform.forward * BulletSpeed * Time.deltaTime;
                    //rb.MovePosition(rb.position + transform.forward * speed * Time.fixedDeltaTime);

                }



            }
        }



    }
}
