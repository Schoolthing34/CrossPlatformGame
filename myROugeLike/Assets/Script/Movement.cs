using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
        
            AndroidUser = false;
            WindowsUser = true;
        }
       
         rb = GetComponent<Rigidbody2D>();
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
        string inputString = UnityEngine.Input.inputString;
        oldPos=transform.position;  
        //Debug.Log(inputString);
        //w
        if(inputString==PlayerMoveUp)
        {
            frontSpeed += SpeedChange;
        }
        else if(inputString==PlayerMoveDown)
        {
             frontSpeed -= SpeedChange;
        }

        if (inputString == PlayerMoveRight)
        {
            sideSpeed += SpeedChange;
        }
        else if (inputString == PlayerMoveLeft)
        {
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


        /*

        if (inputString == PlayerMoveUp)
        {
            //frontSpeed += SpeedChange;
            if (frontSpeed >= MaxSpeed)
            {
                //frontSpeed = MaxSpeed;
            }
            this.transform.position = (new Vector3(0, speed, 0) * Time.deltaTime) + this.transform.position;
            if (rb.velocity.y < MaxSpeed)
            {
                //rb.velocity = new Vector2(rb.velocity.x, MaxSpeed);
            }
            //this.transform.position = (new Vector3(0, speed, 0)*Time.deltaTime)+this.transform.position;
            //rb.AddForce(new Vector2(0,speed)*Time.deltaTime);
        }//s
        else if (inputString == PlayerMoveDown)
        {

           // frontSpeed += -SpeedChange;
           // if (frontSpeed <= -MaxSpeed)
           // {
            //    frontSpeed = -MaxSpeed;
          //  }
            this.transform.position = (new Vector3(0, -speed, 0) * Time.deltaTime) + this.transform.position;
           // if (rb.velocity.y < -MaxSpeed)
          //  {
           //     rb.velocity = new Vector2(rb.velocity.x, -MaxSpeed);
           // }
            //this.transform.position = (new Vector3(0, -speed, 0) * Time.deltaTime) + this.transform.position;
            //  rb.AddForce(new Vector2(0, -speed) * Time.deltaTime);
        }
        else 
        {
            if(frontSpeed >0)
            {
                frontSpeed=frontSpeed-SpeedChange;
            }
            else if(frontSpeed < 0)
            {
                frontSpeed = frontSpeed + SpeedChange;
            }
        }
        */

        /*
        //a
        if (inputString == PlayerMoveLeft)
        {
            sideSpeed += -SpeedChange;
            ;
            if (sideSpeed <= -MaxSpeed)
            {
                sideSpeed = -MaxSpeed;
            }
            rb.MovePosition(new Vector2(((-speed*Time.deltaTime)+this.transform.position.x)
                ,this.transform.position.y));

                 //this.transform.position = (new Vector3(-speed, 0, 0) * Time.deltaTime) + this.transform.position;
                // rb.AddForce(new Vector2(speed, 0) * Time.deltaTime);
              //  rb.velocity += Vector2.right * 50f * sideSpeed * Time.deltaTime;
            if (rb.velocity.x > MaxSpeed)
            {
               // rb.velocity = new Vector2(MaxSpeed, rb.velocity.y);
            }

        }//d
        else if (inputString == PlayerMoveRight)
        {

            sideSpeed += SpeedChange;
            if(sideSpeed>=MaxSpeed)
            {
                sideSpeed = MaxSpeed;
            }
            // this.transform.position = (new Vector3(speed, 0, 0) * Time.deltaTime) + this.transform.position;
            //rb.AddForce(new Vector2(0, 0)*speed);
           // rb.velocity +=Vector2.right* 50f * sideSpeed*Time.deltaTime;
            if (rb.velocity.x < -MaxSpeed)
            {
               // rb.velocity = new Vector2(-MaxSpeed, rb.velocity.y);
            }
            // rb.AddForce(new Vector2(-speed, 0) * Time.deltaTime);

        }
        else
        {
            if (sideSpeed > 0)
            {
                sideSpeed-= SpeedChange;
            }
            else if (sideSpeed < 0)
            {
                sideSpeed+= SpeedChange;
            }
        }
        */
        //  Debug.Log("d"+ UnityEngine.Input.inputString + "d");
        if (inputString == ShootingButton)
        {
            //Debug.Log("Hey shooting1");
            Shoot();
        }//

        
        

    }

    
    public void Shoot()
    {
       // Debug.Log("Hey shooting2");
        GameObject NewBullet = Instantiate(Bullet);
        NewBullet.GetComponent<BasicBulletMovement>().Spawn(this.transform.position,
            new Vector3(this.transform.position.x+1000, 
            this.transform.position.y, 
            this.transform.position.z),
            10f);
        NewBullet.GetComponent<BulletStat>().Spawn(1, 10);
        //Debug.Log("Bang your dead");
    }
}
