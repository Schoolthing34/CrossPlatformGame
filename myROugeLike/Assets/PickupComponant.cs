using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupComponant : MonoBehaviour
{


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

    void Remove()
    {
#if UNITY_EDITOR
        DestroyImmediate(this);
        
#else
        Destroy(this);
#endif

    }


    
}
