using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonLogic : MonoBehaviour
{

    public Button[] Buttons;

    public void RevealLevelOptions()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            if (i < 3)
            {
                Buttons[i].gameObject.SetActive(false);
            }
            else if((i>2)&&(i<6))
            {
                Buttons[i].gameObject.SetActive(true);
            }
        }


       // SceneManager.LoadScene("LevelOne");

    }


    public void StartLevel(int i)
    {
        if (i == 1)
        {
            SceneManager.LoadScene("LevelOne");
        }
        else if (i == 2)
        {
            SceneManager.LoadScene("LevelTwo");
        }
        else if (i == 3)
        {
            SceneManager.LoadScene("LevelThree");
        }

    }
    private void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            Reset();
        }
        //if(Inut.GetKey(""))
    }
    private void Reset()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            if (i < 3)
            {
                Buttons[i].gameObject.SetActive(true);
            }
            else
            {
                Buttons[i].gameObject.SetActive(false);
            }
        }
    }
    public void QuitButtonPressed()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif


    }
}
