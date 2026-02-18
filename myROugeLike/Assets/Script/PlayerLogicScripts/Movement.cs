using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Windows;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private string _playerMoveUo;
    [SerializeField]
    public string PlayerMoveUp
    {
        
        get
        {
            return _playerMoveUo;
        }
        set
        {
            _playerMoveUo = value.ToLower();
           
        }
    }

    

    public string PlayerMoveDown="s";
    public string PlayerMoveLeft="a";
    public string PlayerMoveRight="d";
    public string ShootingButton = " ";
    public float speed=4.5f;
    Rigidbody2D rb;


    //Player Speed
    public float sideSpeed=0;
    public float frontSpeed = 0;
    public float MaxSpeed = 40f;
    public float SpeedChange = 0;
    public Vector3 oldPos;
    public float Deceleration = 0.01f;

    //Ammo
    public GameObject Bullet;

    public bool AndroidUser;
    public bool WindowsUser;
    //Android Controls
    [SerializeField]
    private InputActionReference AndroidInput;
    public float AndroidSpeed;

    public PlayerInput AndroidButtons;
    public bool  UserWantsToShoot=false;

    public Gun PlayerGun;

    //Bullet Stats
   // public float BulletTimer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidUser = true;
            WindowsUser = false;
        }
        else if( (Application.platform == RuntimePlatform.WindowsPlayer)||
            (Application.platform == RuntimePlatform.WindowsEditor)||
            (Application.platform == RuntimePlatform.WindowsServer)
            ) 
            {

            AndroidUser = false; ;
            WindowsUser = true;
        }
       
         rb = GetComponent<Rigidbody2D>();
    }

    public void AndroidUserShooting()
    {
        UserWantsToShoot = true;
    
    }

    // Update is called once per frame
    void Update()
    {
        if (WindowsUser)
        {
            InputManager();
        }
        if (AndroidUser)
        {
            AndroidControls();
        }

       



            //AndroidInput.action.ReadValue<Button>.I
       // if(AndroidInput.ReadValue)
        if (this.transform.position.x < -7.7)
        {
            this.transform.position = new Vector3(-7.7f, this.transform.position.y, this.transform.position.z);
        }
        if (this.transform.position.x > 7.7)
        {
            this.transform.position = new Vector3(7.7f, this.transform.position.y, this.transform.position.z);
        }

        if (this.transform.position.y > 5.0f)
        {
            this.transform.position = new Vector3(this.transform.position.x, 5.0f, this.transform.position.z);
        }
        if (this.transform.position.y < -5.0f)
        {
            this.transform.position = new Vector3(this.transform.position.x, -5.0f, this.transform.position.z);
        }
    }

    private void AndroidControls()
    {
        Vector2 AndroidMoVeDir=AndroidInput.action.ReadValue<Vector2>();



        transform.Translate(AndroidMoVeDir*AndroidSpeed*Time.deltaTime);
    }

    
    public void InputManager()
    {
        //string inputString = UnityEngine.Input.inputString;
        oldPos=transform.position;
        //Debug.Log(inputString);
        //w
        if (UnityEngine.Input.GetKey(PlayerMoveUp))
        {
            if(frontSpeed<0)
            {
                frontSpeed = 0;
            }
            frontSpeed += SpeedChange;
        }
        else if (UnityEngine.Input.GetKey(PlayerMoveDown))
        {
            if (frontSpeed > 0)
            {
                frontSpeed = 0;
            }
            frontSpeed -= SpeedChange;
        }

        if (UnityEngine.Input.GetKey(PlayerMoveRight))
        {
            if (sideSpeed < 0)
            {
                sideSpeed = 0;
            }
            sideSpeed += SpeedChange;
        }
        else if (UnityEngine.Input.GetKey(PlayerMoveLeft))
        {
            if (sideSpeed > 0)
            {
                sideSpeed = 0;
            }
            sideSpeed -= SpeedChange;
        }
        //Speed checks
        if(frontSpeed>MaxSpeed)
        {
            frontSpeed=MaxSpeed;
        }
        else if (frontSpeed < -MaxSpeed)
        {
            frontSpeed=-MaxSpeed;
        }

        if (sideSpeed > MaxSpeed)
        {
            sideSpeed = MaxSpeed;
        }
        else if (sideSpeed < -MaxSpeed)
        {
            sideSpeed = -MaxSpeed;
        }

        this.transform.position += Vector3.right * Time.deltaTime * sideSpeed;
        this.transform.position += Vector3.up * Time.deltaTime * frontSpeed;



        //SpeedDECELLERATIONcHECK
        if(sideSpeed>0)
        {
            sideSpeed -= Deceleration;

        }
        else if (sideSpeed < 0)
        {
            sideSpeed += Deceleration;

        }

        if (frontSpeed > 0)
        {
            frontSpeed -= Deceleration;

        }
        else if (frontSpeed < 0)
        {
            frontSpeed += Deceleration;

        }

        if ((frontSpeed < 0.5) && (frontSpeed > -0.5))
        {
            frontSpeed = 0;
        }
       

        if ((sideSpeed < 0.5) && (sideSpeed > -0.5))
        {
            sideSpeed = 0;
        }
      


        




        //Reduction Speed auto
        if(UnityEngine.Input.GetKeyDown(ShootingButton))
        {
            UserWantsToShoot = true;
        }

        //  Debug.Log("d"+ UnityEngine.Input.inputString + "d");
        if (UserWantsToShoot)
        {
            UserWantsToShoot = false;
            //Debug.Log("Hey shooting1");
            Shoot();
        }//

        
        

    }

    
    public void Shoot()
    {
        PlayerGun.Shoot();
    }
}
