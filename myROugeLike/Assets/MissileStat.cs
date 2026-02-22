using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileStat : BasicBulletMovement
{

    public GameObject ExplosionRadius;
    private bool ExplosionActive = false;
    private float explosionTimer = 0.5f;
    private float MaxSize = 5.69448f;
    private float minSize = 1.281258f;
    private float counter=0;
    private float Change = 00.05f;

   
    public void Explode()
    {
        this.ExplosionRadius.transform.localScale = new Vector3(minSize, minSize, minSize);
        ExplosionRadius.SetActive(true);
        ExplosionActive=true;
        this.gameObject.GetComponent<Renderer>().enabled = false;
        this.gameObject.GetComponent<Collider2D>().enabled = false;

    }


    
    public override void Update()
    {
       if(!ExplosionActive)
        {
            base.Update();
        }

        if (ExplosionActive)
        {
            counter += Time.deltaTime;


            this.ExplosionRadius.transform.localScale += new Vector3(Change, Change, Change);
            if (this.ExplosionRadius.transform.localScale.x > MaxSize)
            {
                ExplosionRadius.SetActive(false);
                ExplosionActive = false;


            }


        }
    }



    // Start is called before the first frame update
    void Start()
    {
       
    }

    
}
