using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
   public AudioClip[] clip;
    AudioSource dave;
    public static void Test(int x,int y,bool yes)
    {
        Debug.Log("TestSuccessful");
       
    }

    public void PlayAudio(int i)
    {
        i--;
        dave.PlayOneShot(clip[i],1);
    }


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.AddComponent<AudioSource>();
        dave= GetComponent<AudioSource>();
        dave.loop = false;
        dave.playOnAwake = false;
        dave.volume = 0.2f;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
