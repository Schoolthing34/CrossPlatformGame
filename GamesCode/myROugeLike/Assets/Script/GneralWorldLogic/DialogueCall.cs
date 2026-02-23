using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCall : MonoBehaviour
{
    public static string GetDialogue(int wave, int Level, bool Boss)
    {


        if (Level == 1)
        {
            if (wave == 1)
            {
                if (Application.platform == RuntimePlatform.Android)
                {
                    return "Hello commander, your job is to defeat the evil aliens \n Use the joystick to move, press the shoot button to shoot\n and if you get any missiles the missiles";
                }
                else
                {
                    return "Hello commander, your job is to defeat the evil aliens \n Use W,A,S,D to move, l to shoot and if you get any k to shoot missiles";
                }
            }
            else if (wave == 2)
            {
                return "Commander the green objects enemies leave behind you can use them run into them to collect them";
            }
            else if (wave == 5)
            {
                return "Well Done Commander your half way to destroying there forces";
            }
            else if (wave == 9)
            {
                return "We have picked up a weird presence near you a boss may\n be approaching be prepared";
            }
            else if (Boss)
            {
                return "I am the destoyer i will not let you harm this planet\n Run If You Can";
            }
        }
        else if (Level == 2)
        {
            if (wave == 1)
            {
                return "Well done commander be careful your in there atmosphere\n here they will have more defensive enemies\n so watch out for ranged attacks  ";
            }
            else if (wave == 5)
            {
                return "Your half way there commander keep going  ";
            }
            else if (wave == 9)
            {
                return "We are picking up reading of alot of enemies coming together\n they may be trying to do Death Ball formation be careful ";
            }
            else if (Boss)
            {
                return "Stop invader we will not allow you to enter our city back away before we are forced to stop you ";
            }
        }
        else if (Level == 3)
        {
            if (wave == 1)
            {
                return "Well done commander you are there city their robotic Queen is the last boss in our way\n we warn you the civilians have been indoctrinated by here\n so be careful  ";
            }
            else if (wave == 5)
            {
                return "You have nearly broken through we believe in you commander ";
            }
            else if (wave == 9)
            {
                return "Commander you are near the Queen don’t fall for here tricks we believe in you ";
            }
            else if (Boss)
            {
                return "Please stop I do not want this, you have kill so many,\n If you don’t leave in 30 seconds my waves of reinforcements will arrive \n so just leave";
            }
        }
        return "";

    

    }

}


