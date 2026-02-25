using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupComponant : MonoBehaviour
{



    [SerializeField]
    public int MissileCount;

    [SerializeField]
   public bool ShieldOn;
    [SerializeField]
    public bool DoubleShot;
    private float DoubleShotTimer = 5.0f;
    private float ShieldTimer = 5.0f;
    private float STimer = 0.0f;
    private float DTimer = 0.0f;
    public bool Cheats = false;
    public void DoubleShotTrue()
    {
        DoubleShot = true;
    }
    public void ActivateShield()
    {
        ShieldOn = true;
    }

    public void AddMissile()
    {
        MissileCount++;

    }
    //needs to know what one it is
    //duration if any
    
    public enum PickupType
    {
        Shield,
        DoubleShot,
        Explosion
    }
    float Duration;


    public void Add(int i,GameObject target)
    {
        if (i == 1)
        {
            target.AddComponent<PickupComponant>();
        }
        else if (i == 2)
        {

        }
        else if (i == 3)
        {


        }
    
    }



    private void Update()
    {
        if(Cheats)
        {
            MissileCount = 999999;
            DoubleShot = true;
            ShieldOn = true;
        }
        if(DoubleShot)
        {
            DTimer += Time.deltaTime;

            if(DTimer>DoubleShotTimer)
            {
                DoubleShot = false;
                DTimer = 0;
            }


        }

        if (ShieldOn)
        {
            STimer += Time.deltaTime;

            if (STimer > ShieldTimer)
            {
                ShieldOn = false;
                STimer = 0;
            }


        }

    }


    void Remove()
    {
#if UNITY_EDITOR
        DestroyImmediate(this);
        
#else
        Destroy(this);
#endif

    }


    
}
