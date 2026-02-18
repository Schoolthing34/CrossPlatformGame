using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RotateToPlayer : MonoBehaviour
{
    private EnemyLogicComponant EnemyLogicComponant;
    private float time;
    private float Offset;
    public bool StartRotating = false;
    public float speed;
    // Start is called before the first frame update
     void Start()
    {
        EnemyLogicComponant = GameObject.Find("EnemyHeadManager").GetComponent<EnemyLogicComponant>();
        if (EnemyLogicComponant == null)
        {
            Debug.LogError("Cant get the enemylogic componant");

        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (StartRotating == true)
        {
            Rotate();
        }
    }
    public void StartRotation(float offset,float time)
    {
        Offset=offset;
        this.time = time;
        StartRotating = true;
    }
    //hello note  this code isnt the most accurate whatcan you do
    private void Rotate()
    {
        Vector3 player = EnemyLogicComponant.ReturnPlayerPosition();

        player.z = 0f;
        Quaternion ObjectXYKeeper = this.transform.rotation;
        Vector3 objectPos = transform.position;
        player.x = player.x - objectPos.x;
        player.y = player.y - objectPos.y;

        float angle = Mathf.Atan2(player.y, player.x) * Mathf.Rad2Deg;
         angle += Offset;
       // Debug.Log(this.transform.rotation);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        //transform.Rotate(0,0,angle);
        // transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        //Quaternion.Euler(new Vector3(0,0 , angle));
        // transform.rotation =  Quaternion.Euler(new Vector3(ObjectXYKeeper.x,0,this.transform.rotation.z));
        //this.transform.rotation;
        //Quaternion.Euler(new Vector3(this.transform.rotation.x, this.transform.rotation.y, angle));


        // omg im losing my fucking mind
        // get a rotation that points Z axis forward, and the Y axis towards the target
        // Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, (player));

        // rotate toward the target rotation, never rotating farther than "lookSpeed" in one frame.
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed);

        // rotate 90 degrees around the Z axis to point X axis instead of Y
        // transform.Rotate(0, 0, 1);

        // Quaternion targetRotation = Quaternion.LookRotation(player - transform.position);
        //speed = Mathf.Min(speed * Time.deltaTime, 1);
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed);




        time -= Time.deltaTime;
        //Debug.Log(this.transform.rotation);
        if (time<0)
        {
            StartRotating=false;
        }

    }
}
