using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
   
    // Start is called before the first frame update
    void Start()
    {
        PlayerMoveUp = "w";
         rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputManager();
    }

    public void InputManager()
    {
        string inputString = UnityEngine.Input.inputString;
       
        //Debug.Log(inputString);
        //w
        if (inputString == PlayerMoveUp)
        {
            this.transform.position = (new Vector3(0, speed, 0)*Time.deltaTime)+this.transform.position;
            //rb.AddForce(new Vector2(0,speed)*Time.deltaTime);
        }//s
        else if (inputString == PlayerMoveDown)
        {
            this.transform.position = (new Vector3(0, -speed, 0) * Time.deltaTime) + this.transform.position;
          //  rb.AddForce(new Vector2(0, -speed) * Time.deltaTime);
        }
        
        
        
        //a
         if (inputString == PlayerMoveLeft)
        {
            this.transform.position = (new Vector3(-speed, 0, 0) * Time.deltaTime) + this.transform.position;
           // rb.AddForce(new Vector2(speed, 0) * Time.deltaTime);

        }//d
        else if (inputString == PlayerMoveRight)
        {
            this.transform.position = (new Vector3(speed, 0, 0) * Time.deltaTime) + this.transform.position;
           // rb.AddForce(new Vector2(-speed, 0) * Time.deltaTime);
          
        }
        
      //  Debug.Log("d"+ UnityEngine.Input.inputString + "d");
        if (inputString == ShootingButton)
        {
            Shoot();
        }

    }
    public void Shoot()
    {
        Debug.Log("Bang your dead");
    }
}
