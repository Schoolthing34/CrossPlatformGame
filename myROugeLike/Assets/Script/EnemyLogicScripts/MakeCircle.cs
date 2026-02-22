using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCircle : BaseEnemy
{


    
    

    public override void Spawn(Vector3 StartTarget, float Xdirection, float YDirection, int speed = 1, int Heath = 5, int rank = 1)
    {
        this.transform.position=StartTarget;

    }

    public void Spawn(Vector3 StartTarget,float Size, int speed = 1, int Heath = 10)
    {
        this.transform.position = StartTarget;
        this.transform.localScale=new Vector3(Size,Size,Size);
        base.EnemyHealth = Heath;



        
    }


    // Update is called once per frame

}
