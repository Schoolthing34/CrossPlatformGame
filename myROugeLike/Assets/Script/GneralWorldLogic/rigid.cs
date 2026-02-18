using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private float ScreenWidth;
    // Update is called once per frame
    void Update()
    {
    if(Application.platform==RuntimePlatform.Android)
        {

        }
    else  if((Application.platform==RuntimePlatform.WindowsPlayer)||(Application.platform == RuntimePlatform.WindowsEditor))
        {
            Vector2 playpos=Input.GetTouch(0).position;
        }
     }
}
