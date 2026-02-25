using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletMovementEnemy : MonoBehaviour
{
    MoveOffScreenFromPositionScript movement;
  
    public Vector3 StartPos;
    bool Shooting = false;
    float Speed;
    bool Right;
    // Start is called before the first frame update
    void Start()
    {
        movement = this.gameObject.GetComponent<MoveOffScreenFromPositionScript>();
        if (movement == null)
        {
            Debug.LogError("Cant get the Movement componant");

        }
        //Spawn(1,false);
    }
    public void Spawn(float Speed, Vector3 target)
    {

        Start();
       
            movement.MoveToSpecificPiont(target.x, target.y,3 );
            StartPos = this.transform.position;
            
        
        
    }


   public void Spawn(float Speed,bool right)
    {
        this.Speed = Speed;
        Shooting = true;
        this.Right = right;
    }
    private void Update()
    {
        if(Vector3.Distance(this.transform.position,StartPos)>20)
        {
            Destroy(this.gameObject);
        }

        if(Shooting)
        {
            if(Right)
            {
                transform.position += Vector3.right * Speed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.left * Speed * Time.deltaTime;
            }


            transform.position += Vector3.up * Speed * Time.deltaTime;

        }
    }




}
