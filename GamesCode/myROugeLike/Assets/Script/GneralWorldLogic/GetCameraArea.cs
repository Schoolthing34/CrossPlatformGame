using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class GetMovemntArea : MonoBehaviour
{
    private float x;
    private float y;
    Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        // Vector3 p = cam.ViewportToWorldPoint(new Vector3(1, 1,0));
        //Debug.Log(p);
        // 7 to -7 onn x 4 to negative 4 on y

    }


    public Vector3 ReturnBottomLeft()
    {
        if(cam == null) {
            
                cam = GetComponent<Camera>();
            }
        Vector3 p = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));

        return p;
    }
    public Vector3 ReturnTopRight()
    {
        if (cam == null)
        {

            cam = GetComponent<Camera>();
        }
        Vector3 p = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

        return p;
    }
}
