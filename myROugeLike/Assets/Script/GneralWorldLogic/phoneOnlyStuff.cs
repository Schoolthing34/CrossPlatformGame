using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phoneOnlyStuff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
           this.gameObject.SetActive(false);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
