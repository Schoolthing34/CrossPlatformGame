using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeOfDeviceScript : MonoBehaviour
{
    public bool PhoneUser = false;
    public bool ComputerUser=true;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if ((Application.isMobilePlatform) && (Application.platform == RuntimePlatform.WebGLPlayer))
        {
            PhoneUser = true;
            ComputerUser = false;
        }
        else
        {

            PhoneUser = false;
            ComputerUser = true;
        }
    }


    public void CompterUser()
    {
        PhoneUser = false;
        ComputerUser = true;
    
    }

    public void MobileUser()
    {
        PhoneUser = true;
        ComputerUser = false;

    }
}
