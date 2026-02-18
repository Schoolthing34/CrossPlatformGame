using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogicComponant : MonoBehaviour
{


    private GameObject Player;



   public  Vector3 ReturnPlayerPosition()
    {
        if(Player==null)
        {
            return Vector3.zero;
        }
        return Player.transform.position;   
    }

   public Vector3 DistanceToPlayer(Vector3 Us)
    {
        return Player.transform.position - Us;
    }


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
