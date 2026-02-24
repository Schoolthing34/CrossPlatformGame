using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

     TextMeshProUGUI LeftText;
     TextMeshProUGUI MiddleText;
     TextMeshProUGUI RightText;
    
    // Start is called before the first frame update
    void Start()
    {


        GameObject dave=GameObject.Find("LeftWaveText"); ;
        LeftText = dave.gameObject.GetComponent<TextMeshProUGUI>();


         dave = GameObject.Find("MiddleDialogueText"); ;
        MiddleText = dave.gameObject.GetComponent<TextMeshProUGUI>();
        dave = GameObject.Find("CounterText"); ;
        RightText = dave.gameObject.GetComponent<TextMeshProUGUI>();
        LeftText.text = "";
        MiddleText.text = "";
        RightText.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void UpdateLeftText(string leftText)
    {
       

        this.LeftText.SetText(leftText);

    }


    public void UpdateMiddleText(string MiddleText)
    {


        this.MiddleText.SetText(MiddleText);

    }
    public void UpdateRightText(string RightText)
    {


        this.RightText.SetText(RightText);

    }
}
