using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{

    private bool IsPlayer;
    private bool IsEnemy;
    private bool IsBullet;


    private void Start()
    {
        if(this.gameObject.tag=="Player")
        {
            IsPlayer = true;
            IsEnemy = false;
            IsBullet = false;
        }
        else if (this.gameObject.tag == "Enemy")
        {
            IsPlayer = false;
            IsEnemy = true;
            IsBullet = false;
        }
        else if (this.gameObject.tag == "Bullet")
        {
            IsPlayer = false;
            IsEnemy = false;
            IsBullet = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(IsPlayer)
        {
            PlayerCollision(collision.gameObject);
        }
        else if (IsEnemy)
        {
            EnemyCollision(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsPlayer)
        {
            PlayerCollision(collision.gameObject);
        }
        else if (IsEnemy)
        {
           // Debug.Log("Hey enemy ");
            EnemyCollision(collision.gameObject);
        }
    }


    private void EnemyCollision(GameObject other)
    {
        //Debug.Log("Hey enemy hit can be at least");
        if (other.tag=="Bullet")
        {
            Debug.Log("Hey enemy hit");
            int damage = other.GetComponent<BulletStat>().damage;
            gameObject.SendMessage( "Damage", damage);
            Destroy(other.gameObject);
        }
        

    }
    public void PlayerCollision(GameObject HitObject)
    {
       // Debug.Log("Hit"+HitObject.name);
        if (HitObject.tag=="InvisibleWalls")
        {
           // Debug.Log("Speeling corrrect");
            transform.position = this.gameObject.GetComponent<Movement>().oldPos;
            transform.position = this.gameObject.GetComponent<Movement>().oldPos;
        }
        else if (HitObject.tag == "Enemy")
        {
          //  Debug.Log("Game Over player was hit by an enemy named " + HitObject.name);
            Destroy(HitObject);
            Destroy(this.gameObject);

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
       

    }
}
