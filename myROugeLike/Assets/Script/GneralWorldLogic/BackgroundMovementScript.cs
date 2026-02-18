using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovementScript : MonoBehaviour
{


    //this script is made to make the backgorund look like its moving 
    //to do this lets set up a simple 2 object system with a 3rd object for telport back
    public GameObject Background1;
    public GameObject Background2;
    public GameObject StartPos;
    public GameObject EndPos;
    public float Speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Background1.transform.position += Vector3.right * Time.deltaTime * Speed;
        Background2.transform.position += Vector3.right * Time.deltaTime * Speed;

        if(Background1.transform.position.x>EndPos.transform.position.x)
        {
            Background1.transform.position=StartPos.transform.position;
        }
        if (Background2.transform.position.x > EndPos.transform.position.x)
        {
            Background2.transform.position = StartPos.transform.position;
        }

    }
}
