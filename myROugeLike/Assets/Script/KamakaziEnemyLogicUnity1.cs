using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class KamakaziEnemyLogicUnity : MonoBehaviour
{

    public EnemyLogicComponant EnemyLogicComponant;
    public MoveOffScreenFromPositionScript Movement;
    public RotateToPlayer Rotation;
    public GetMovemntArea MovementNumbers;
    public bool aiming;
    public bool moving;
    public bool dying;
    public float speed;
    public  void Spawn(Vector3 StartTarget, float Xdirection, float YDirection, float speed = 1)
    {
        this.transform.position = StartTarget;
        aiming = false;
        moving = true;
        dying = false;
        Movement.MoveTo(1,0,speed);
    }
    // Start is called before the first frame update
    public  void Start()
    {
        Movement = this.gameObject.GetComponent<MoveOffScreenFromPositionScript>();
        if (Movement == null)
        {
            Debug.LogError("Cant get the Movement componant");

        }

        Rotation = this.gameObject.GetComponent<RotateToPlayer>();
        if (Rotation == null)
        {
            Debug.LogError("Cant get the Rotation componant");

        }
        MovementNumbers = GameObject.Find("Moveable Area").GetComponent<GetMovemntArea>();
        Spawn(this.transform.position, 4, 0, 1);
    }


    // Update is called once per frame
    public  void Update()
    {
        if (moving)
        {
            if (!Movement.move)
            {
                moving = false;
                aiming = true;
                Rotation.StartRotation(0, 3);


            }
        }

            if(aiming)
            {
                if(!Rotation.StartRotating)
                {
                    aiming = false;

                    //Movement.MoveTo(100, 0, speed);
                    dying = true;
                }
            }

            if(dying)
            {
            transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
            //if(!Movement.move)
            //{
            //   Destroy(this.gameObject);
            // }


        }
        
    }       


    //okay so yeah lets them go forever
}
