using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class MoveOffScreenFromPositionScript : MonoBehaviour
{

    public Vector3 Position;
    public Vector3 Target;
    public float Speed=1;
    public bool move = false;
   public void  MoveTo(float XDir=0,float YDir=0,float Speed=1)
    {
        Position = this.transform.position;
        Target = Position+ new Vector3(XDir, YDir, 0);
        this.Speed = Speed;
       

        move = true;
       // Debug.Log("CalledMovemetn");
    
    }

    public void MoveToSpecificPiont(float XDir = 0, float YDir = 0, float Speed = 1)
    {
        Position = this.transform.position;
        Target =  new Vector3(XDir, YDir, 0);
        this.Speed = Speed;


        move = true;
    }
    private void Update()
    {
       // Debug.Log("test");
           if(move)
        {
            //Debug.Log("We moving");
            float dave = Speed * Time.deltaTime;
            this.transform.position=Vector3.MoveTowards(this.transform.position, Target, dave);
            if (this.transform.position == Target)
            {
               // Debug.Log("Movemetn Over");
                move = false;
            }
        }

           
    }

}
