using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovementEnemy : MonoBehaviour
{
    MoveOffScreenFromPositionScript movement;

    public Vector3 StartPos;

    // Start is called before the first frame update
    void Start()
    {
        movement = this.gameObject.GetComponent<MoveOffScreenFromPositionScript>();
        if (movement == null)
        {
            Debug.LogError("Cant get the Movement componant");

        }
    }
    public void Spawn(float Speed)
    {
        Start();
        movement.MoveTo(-100,0,Speed);
        StartPos=this.transform.position;
    }





    // Update is called once per frame
    void Update()
    {
       
    }
}
