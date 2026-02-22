using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Guy : BaseEnemy
{

    const float GuyY = -4.18f;
    const float xMax = 12;
    const float Xmin = -12;
    bool Spawned=false;

    bool GoLeft = false;
    bool GoRight = false;
    float Speed;
    public float MissileSpeed;
    public GameObject Missile;

    private float ShootTimer=3.0f;
    private float counter = 0;

    
    void Start()
    {
        if (base.Testing)
        {
            Spawn(new Vector3(0, 0, 0), 0, 0);
        }
    }


    public override void Spawn(Vector3 StartTarget, float Xdirection, float YDirection, int speed = 2, int Heath = 1, int rank = 1)
    {
        if (!Testing)
        {
            Start();
        }
        float x = Random.Range(1,10);
        if(x%2==0)
        {
            x = 10;
            GoLeft = true;
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else
        {
            x = -9;
            GoRight = true;
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 187.00119f, 0));
        }
       // float x = Random.Range(MinX, MaxX);
        this.transform.position = new Vector3(x, GuyY, 0);
        base.EnemyHealth = Heath;

        Spawned = true;
        Speed = speed;
       // Debug.Log("Hey we Spawned left "+GoLeft+" Right "+GoRight);


        
    }


    Vector3 MissileRotation()
    {

        if (GoLeft)
        {
            return new Vector3(0, 0, -26.097f);
        }
        else if (GoRight)
        {
            return new Vector3(2.49529982f, 185.084351f, 333.925781f);
        }
        else
        {
            Debug.LogError("Need to be goign right or left");
        }
        
        
        return Vector3.zero;
    }


    private void Shoot()
    {
        GameObject TempMissile = Instantiate(Missile);
        TempMissile.transform.position = this.transform.position;

        TempMissile.transform.rotation = Quaternion.Euler(MissileRotation());
        TempMissile.transform.localScale = Missile.transform.localScale;
        TempMissile.GetComponent<BulletMovementEnemy>().Spawn(MissileSpeed, GoRight);


    }
    // Update is called once per frame
    void Update()
    {
        if(Spawned)
        {
            //Debug.Log("Hey we Spawned2");
            if (GoRight  )
            {
               // Debug.Log("Hey we Right");
                transform.position+=Vector3.right * Speed * Time.deltaTime;


                if (this.transform.position.x > xMax)
                {
                    GoRight = false;
                    GoLeft = true;
                    this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                }

            }

            else if (GoLeft)
            {
                //Debug.Log("Hey we Left");
                transform.position -= Vector3.right * Speed * Time.deltaTime;


                if(this.transform.position.x< Xmin)
                {
                    GoRight = true;
                    GoLeft=false;
                    this.transform.rotation = Quaternion.Euler(new Vector3(0, 187.00119f, 0));
                       // Quaternian.EurlarVector3(0, 187.00119, 0);
                }

            }




            counter += Time.deltaTime;
            if (counter > ShootTimer)
            {


                counter = 0;
                Shoot();


            }
        }


       


    }
}
