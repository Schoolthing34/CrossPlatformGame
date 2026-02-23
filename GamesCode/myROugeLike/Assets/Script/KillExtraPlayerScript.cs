using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillExtraPlayerScript : MonoBehaviour
{
    int PlayerLevelFromInt;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name=="LevelOne")
        {
            PlayerLevelFromInt = 1;
            this.gameObject.name = "Player" + PlayerLevelFromInt;
        }
        if (SceneManager.GetActiveScene().name == "LevelTwo")
        {
            PlayerLevelFromInt = 2;
            this.gameObject.name = "Player" + PlayerLevelFromInt;
        }
        if (SceneManager.GetActiveScene().name == "LevelThree")
        {
            PlayerLevelFromInt = 3;
            this.gameObject.name = "Player" + PlayerLevelFromInt;
            
        }

        KillOthersIfExist();
    }
    private void KillOthersIfExist()
    {




        if (PlayerLevelFromInt == 1)
        {
            GameObject two = GameObject.Find("Player2");

            if (two != null)
            {
                Destroy(two);
            }

            GameObject three = GameObject.Find("Player3");

            if (three != null)
            {
                Destroy(three);
            }
        }
        else if(PlayerLevelFromInt==2)
        {
            GameObject One = GameObject.Find("Player1");

            if (One != null)
            {
                Destroy(this.gameObject);
            }

            GameObject three = GameObject.Find("Player3");

            if (three != null)
            {
                Destroy(three);
            }
        }
        else if (PlayerLevelFromInt == 3)
        {
            GameObject One = GameObject.Find("Player1");

            if (One != null)
            {
                Destroy(this.gameObject);
            }

            GameObject two = GameObject.Find("Player2");

            if (two != null)
            {
                Destroy(this.gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
