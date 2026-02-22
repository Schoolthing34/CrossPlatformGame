using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.PackageManager;
using UnityEngine;

public class ShieldRotating : MonoBehaviour
{


    public bool Rotating=false;

    public float RotationSpeed;


    public bool RotateX;
    public bool RotateY;
    public bool RotateZ;

    public float AngleWanted;

    [Description ]
    ///"Please enter 1,2 or 3 for the firection of the object, x=1.y=2.z=3"
    public void StartRotating(int XYZNumYes,float AngleWanted)
    {

        switch(XYZNumYes)
        {
            case 1:
                RotateX = true;
                break;
            case 2:
                RotateY = true;
                break;
            case 3:
                RotateZ = true;
                break;

            default:
                Debug.LogError("Input invalid bool check number nees to be eihter 1 forx two for y and 3 for z");
                break;


        }

        this.AngleWanted = AngleWanted;
        Rotating = true;

    }

    public void StartRotating()
    {
        Rotating = true;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Rotating)
        {
            float X=0,Y=0,Z=0;
            if (RotateX)
            {
                X = RotationSpeed;
                if (this.transform.rotation.eulerAngles.x >= AngleWanted)
                {
                    Rotating = false;
                }
            }
            else if (RotateY)
            {
                Y = RotationSpeed;
               // Debug.Log(this.transform.rotation.eulerAngles + " " + AngleWanted);
                if (this.transform.rotation.eulerAngles.y > AngleWanted)
                {
                    Rotating = false;
                }
            }
            else if (RotateZ)
            {
                Z = RotationSpeed;
                if (this.transform.rotation.eulerAngles.z >= AngleWanted)
                {
                    Rotating=false;
                }
            }
            else
            {
                Rotating = false;
            }
                transform.Rotate(new Vector3(X,Y,Z));


            
            
        }
    }
}
