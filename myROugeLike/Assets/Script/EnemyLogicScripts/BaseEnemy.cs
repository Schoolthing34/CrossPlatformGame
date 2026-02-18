using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public int EnemyHealth;
    public int Ranking;


    virtual public void Spawn(Vector3 StartTarget, float Xdirection, float YDirection, int speed = 1, int Heath = 1, int rank = 1)
    {
        Debug.Log("Should not access this one");
    }


    public void Damage(int damage)
    {
       // Debug.Log("Hey enemy hit");
        EnemyHealth -= damage;

        if(EnemyHealth < 0 )
        {
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }
}
