using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMoveLeft : MonoBehaviour
{

    Vector3 StartPos;
    // Start is called before the first frame update
    void Start()
    {
        StartPos= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * 2 * Time.deltaTime;


        if(Vector3.Distance(StartPos,this.transform.position)>25)
        {
            Destroy(this.gameObject);
        }
    }
}
