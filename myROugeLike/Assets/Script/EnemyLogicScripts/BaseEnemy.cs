using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BaseEnemy : MonoBehaviour
{
    public int EnemyHealth;
    public int Ranking;
    public bool Testing = false;
    public GameObject Pickups;
   
    virtual public void Spawn(Vector3 StartTarget, float Xdirection, float YDirection, int speed = 1, int Heath = 1, int rank = 1)
    {
        Debug.Log("Should not access this one");
    }


    public void Damage(int damage)
    {
       // Debug.Log("Hey enemy hit");
        EnemyHealth -= damage;

        if(EnemyHealth <= 0 )
        {
            this.gameObject.SetActive(false);
            Debug.Log("Hey this guy died"+this.gameObject.name);
            Pickups = GameObject.Find("PickupHolder");
            int Chance = Random.Range(1,100);
            if (Chance > 80)
            {
                if (Pickups != null)
                {
                    int newNum = Random.Range(0,10);
                    GameObject steve;
                    //Missile Options
                    if(newNum<=4)
                    {
                       steve= Instantiate(Pickups.GetComponent<AllPickups>().MissilePickup,this.transform.position,this.transform.rotation);
                        steve.name = "MissilePickup";
                    }
                    if ((newNum <= 7)&&(newNum >= 4))
                    {
                        steve = Instantiate(Pickups.GetComponent<AllPickups>().ShieldPickUp, this.transform.position, this.transform.rotation);
                        steve.name = "ShieldPickUp";
                    }
                    if (newNum >= 7)
                    {
                        steve = Instantiate(Pickups.GetComponent<AllPickups>().DoubleShotPickup, this.transform.position, this.transform.rotation);
                        steve.name = "DoubleShotPickUp";
                    }
                   // Instantiate(Pickups.GetComponent<AllPickups>().DoubleShotPickup);
                }
            }
            


            //Destroy(this.gameObject);
        }
    }
}
