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
        if (this.gameObject.tag == "Player")
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

        if (IsPlayer)
        {
            PlayerCollision(collision.gameObject);
        }
        else if (IsEnemy)
        {
            //Debug.Log(this.gameObject.name + " " + collision.gameObject.name);
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
        else if (IsBullet)
        {
            BulletCollision(collision.gameObject);
        }
    }

    private void BulletCollision(GameObject other)
    {
        if (other.tag == "Enemy")
        {
            
        }

    }
    private void EnemyCollision(GameObject other)
    {
        //Debug.Log("Hey enemy hit can be at least");
        if (other.tag=="Bullet")
        {
            if((this.name != "Beem") && (this.gameObject.layer!=10))
             {
               // Debug.Log("Hey enemy hit");
                int damage = other.GetComponent<BulletStat>().damage;
                if (this.gameObject != null)
                {
                    gameObject.SendMessage("Damage", damage,SendMessageOptions.DontRequireReceiver);
                }
            }
            
            Destroy(other.gameObject);
        }
        else if(other.tag=="Missile")
        {

            if ((this.name != "Beem") && (this.gameObject.layer != 10))
            {
                other.gameObject.GetComponent<MissileStat>().Explode();

                int damage = other.GetComponent<BulletStat>().damage;
                if (this.gameObject != null)
                {
                    gameObject.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);
                }
                //Destroy(this.gameObject);
            }
            
            
        }
        else if (other.tag == "Explosion")
        {
            int damage = 5;
            gameObject.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);

        }
        else if (other.tag == "PlayerShield")
        {
            int damage = 3;
            gameObject.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);
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
            if ((HitObject.name != "Beem")&&(HitObject.layer != 12))
            {
                Destroy(HitObject);
            }

            Destroy(this.gameObject);

            SceneManager.LoadScene("IntroMenuScene");

        }
        else if(HitObject.tag =="EnemyProjectile")
        {
            Destroy(HitObject);
            Destroy(this.gameObject);

            SceneManager.LoadScene("IntroMenuScene");
        }
        else if(HitObject.tag=="Lightning")
        {
            //Destroy(HitObject);
            Destroy(this.gameObject);

            SceneManager.LoadScene("IntroMenuScene");
        }
        else if(HitObject.tag=="PickUp")
        {
            if(HitObject.name == "MissilePickup")
            {
                gameObject.SendMessage("AddMissile");
                Destroy(HitObject.gameObject);
            }
            else if (HitObject.name == "ShieldPickUp")
            {
                gameObject.SendMessage("ActivateShield");
                Destroy(HitObject.gameObject);
            }
            else if (HitObject.name == "DoubleShotPickUp")
            {
                gameObject.SendMessage("DoubleShotTrue");
                Destroy(HitObject.gameObject);
            }
        }

    }
}
