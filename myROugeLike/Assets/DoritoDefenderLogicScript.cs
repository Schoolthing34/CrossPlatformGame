using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoritoDefenderLogicScript : BaseEnemy
{


    public MoveOffScreenFromPositionScript movement;
    public GameObject Bullet;


    //okay tired so here i go
    //logic
    public bool Entrance;
    public bool MoveUp;
    public bool MoveDown;
    public bool Shoot;


    public float YMax;
    public float YMin;
    public float Timer;
    public float ShootTime;


    private List<GameObject> Bullets = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        movement = this.gameObject.GetComponent<MoveOffScreenFromPositionScript>();
        if (movement == null)
        {
            Debug.LogError("Cant get the Movement componant");

        }
      //  Spawn(new Vector3(0,0,0),0,0);
    }


    public override void Spawn(Vector3 StartTarget, float Xdirection, float YDirection, int speed = 1, int Heath = 1, int rank = 1)
    {
        Start();
       this.transform.position = StartTarget;
        //  movement.MoveToSpecificPiont(,transform.position.y,speed);
        movement.MoveTo(-5);
        Entrance = true;
        MoveUp = false;
        MoveDown = false;
        Shoot = false;



    }
    // Update is called once per frame
    void Update()
    {
        if(Entrance)
        {
            if(!movement.move)
            {
                NextMovement();
                Entrance = false;
                //StartCoroutine("ShootBullet",5.0f);
            }
        }

        if ((MoveUp) || (MoveDown))
        {
            if (!movement.move)
            {
                if(MoveUp)
                {
                    MoveDown = true;
                    MoveUp = false;
                    movement.MoveToSpecificPiont(this.transform.position.x, YMax, 1);
                }
                else if(MoveDown)
                {
                    MoveDown = false;
                    MoveUp = true;
                    movement.MoveToSpecificPiont(this.transform.position.x, YMin, 1);
                }
            }

            Timer += Time.deltaTime;


            if(Timer>ShootTime)
            {
                ShootBullet();
                Timer = 0;

                if (Bullets.Count > 0)
                {
                    for (int i = Bullets.Count-1; i > 0; i--)
                    {
                        if (Vector3.Distance(Bullets[i].GetComponent<BulletMovementEnemy>().StartPos, Bullets[i].transform.position) > 20)
                        {
                            Destroy(Bullets[i]);
                            Bullets.Remove(Bullets[i]);
                        }
                    }
                }
            }


        }
        




    }


    void NextMovement()
    {
        int rand = Random.Range(1, 3);

        if (rand == 1)
        {
            MoveUp = true;
            movement.MoveToSpecificPiont(this.transform.position.x, YMax, 1);
        }
        else if (rand == 2)
        {
            MoveDown = true;
            movement.MoveToSpecificPiont(this.transform.position.x, YMin, 1);
        }


    }


    void ShootBullet()
    {
        GameObject temp = Instantiate(Bullet,this.transform.position,this.transform.rotation);
        temp.GetComponent<BulletMovementEnemy>().Spawn(5);
        Bullets.Add(temp);


    
    
    }
}
