using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionIgnoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(7,9);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
