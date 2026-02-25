using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitScript : MonoBehaviour
{
   



    public void QuitButtonPressed()
    {
        SceneManager.LoadScene("IntroMenuScene");
    }
}
