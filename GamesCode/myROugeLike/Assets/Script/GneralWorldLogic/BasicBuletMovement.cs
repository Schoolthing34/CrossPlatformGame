using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BasicBulletMovement : MonoBehaviour
{




   
    private Vector3 Direction;
    private float speed=10;
    public Vector3 TargetPosition=new Vector3(0,0,0);

    //add sprite to make it easier to be custom
    public void Spawn(Vector3 CurrentPos,Vector3 targetPos, float speed)
    {
        TargetPosition = targetPos;
        this.transform.position = CurrentPos;
        this.speed = speed;
        Direction=(targetPos-CurrentPos).normalized;
        
    }

    
   public virtual void Update()
    {
        BulletMovement();
    }

    private void BulletMovement()
    {
        this.transform.position += Direction.normalized*speed*Time.deltaTime;
    }

    private void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}
