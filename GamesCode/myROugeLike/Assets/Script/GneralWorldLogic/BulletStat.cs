using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStat : MonoBehaviour
{
    public int damage;
    public float speed;
    public virtual void Spawn(int damage,int Speed)
    {
        this.damage = damage;
        this.speed = Speed;
    }
}
