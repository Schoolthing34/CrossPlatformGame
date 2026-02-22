using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> ActiveEnemies=new List<GameObject>();
    public GameObject[] Enemies;
    public GameObject BossThisLevel;
   // public GameObject[] ActiveEnemies;
    public int CurrentLevel = 0;
    public int LevelTimer;
    //1 to 3 willbe the level itself
    //-1 will be menu and others will be other logic stuff


    //Specific LevelStuff
    int WaveTimer;
    //time between enemy spawns
    bool WaveOn;
    bool WaveDead;
   public  float LevelOn = 0.00f;

    int WaveAmount;
    public int CurrentWaveSPawned;
    int ActualWave;
    bool BossSpawned;
    //enemy stuff
    int MaxNumAllowed,MinNumAllowed;

    public bool TestingBoss = false;
    int MaxShieldAllowed=3;
    int ShieldSpawned = 0;
    GameObject SpeechManager;
    public GameObject Button1;
    public GameObject Button2;
    bool LeavingLevel;
    private void Start()
    {
        if(SceneManager.GetActiveScene().name=="LevelOne")
        {
            StartLevel(1, 180);
        }
        if (SceneManager.GetActiveScene().name == "LevelTwo")
        {
            StartLevel(2, 180);
        }
        if (SceneManager.GetActiveScene().name == "LevelThree")
        {
            StartLevel(3, 180);
        }

        SpeechManager = GameObject.Find("SpeechManager");
       // if(SpeechManager==null)
        //{
        //    Debug.LogError("Omg im losing my fuckign mind");
        //}
       // SpeechManager.GetComponent<DialogueManager>().UpdateLeftText("Wave: "+ActualWave);
    }
    public void StartLevel(int Level,int LevelTimer)
    {
        Button1.SetActive(false);
        Button2.SetActive(false);
        LevelOn = 0.00f;
        CurrentLevel = Level;
        this.LevelTimer = LevelTimer;
        CurrentWaveSPawned = 0;
        LevelOn = 0;
        LeavingLevel = false;
        if (TestingBoss)
        {
            ActualWave = 10;
        }
        else
        {
            ActualWave =0;
        }
        WaveDead = true;
        BossSpawned = false;
        switch(CurrentLevel)
            {
            case 1:
                WaveTimer = 1;
                WaveAmount = 10;
                MinNumAllowed = 1;
                MaxNumAllowed = 2;


                break;
            case 2:
                WaveTimer = 1;
                WaveAmount = 10;
                MinNumAllowed = 1;
                MaxNumAllowed = 4;
                break;
            case 3:
                WaveTimer = 1;
                WaveAmount = 10;
                MinNumAllowed = 1;
                MaxNumAllowed = 6;
                break;
            case 0:
                break;

        }


        WaveOn = true;
    }




    private void Update()
    {

        if (WaveOn)
        {
            if (WaveDead)
            { 
              if ((ActualWave < CurrentWaveSPawned) && (WaveDead) && (ActualWave != WaveAmount))
                 {
                  WaveDead = false;
                    ActualWave++;
                   SpawnNextWave();
                 }
                else if ((ActualWave == WaveAmount) && (!BossSpawned))
                {
                  BossSpawned = true;
                    SpawnBoss();
                }
            }
            // Debug.Log(LevelOn % WaveTimer);
            if (LevelOn > WaveTimer)
            {
                if(CurrentWaveSPawned!=WaveAmount)
                {
                    CurrentWaveSPawned++;
                }

                

                LevelOn -= WaveTimer;

            }
            bool check = true;
            if (ActiveEnemies.Count > 0)

            {
                for (int i = ActiveEnemies.Count-1; i >= 0; i--)
                {
                    //Debug.Log("i= "+i);


                    if (ActiveEnemies[i]==null)
                    {
                        Destroy(ActiveEnemies[i].gameObject);
                        ActiveEnemies.Remove(ActiveEnemies[i]);
                    }
                    else if (ActiveEnemies[i].activeSelf)
                    {
                        check = false;
                    }
                  
                }
            }
           if(check)
            {
                WaveDead = true;
                if(BossSpawned)
                {

                    //by this point the boos is dead so lets just do some things


                    StartEndingLevelCutscene();
                    
                    
                   // Application.LoadLevel("IntroMenuScene");
                }
            }

            
            
            LevelOn += Time.deltaTime;
        }
    }
    

    private void StartEndingLevelCutscene()
    {
        GameObject Speech = GameObject.Find("SpeechManager");
        string Text1 = " ";
        if (SceneManager.GetActiveScene().name == "LevelOne")
        {
             Text1 = "Hello Hello, Well Done Commander you have broken through \nthe evil aliens front lines, you will now need ot enter their atmasphere\n be careful the defences will only get more tougher from here \n We Believe in you are our only hope to avenge what they did  ";

        }
        else if (SceneManager.GetActiveScene().name == "LevelTwo")
        {
            Text1 = "Hello Hello, Well Done Commander you have broken through \nthe evil aliens front lines, you will now need ot enter their atmasphere\n be careful the defences will only get more tougher from here \n We Believe in you are our only hope to avenge what they did  ";

        }
        else if (SceneManager.GetActiveScene().name == "LevelThree")
        {
            Text1 = "Hello Hello, Well Done Commander you have broken through \nthe evil aliens front lines, you will now need ot enter their atmasphere\n be careful the defences will only get more tougher from here \n We Believe in you are our only hope to avenge what they did  ";

        }

        Speech.GetComponent<DialogueManager>().UpdateMiddleText(Text1);
        
            Button1.SetActive(true);
            Button2.SetActive(true);


            
        
    }

    public void NextLevelButtonPressed()
    {
        if (SceneManager.GetActiveScene().name == "LevelOne")
        {
            SceneManager.LoadScene("LevelTwo");
        }
        else if (SceneManager.GetActiveScene().name == "LevelTwo")
        {
            SceneManager.LoadScene("LevelThree");
        }
        else if(SceneManager.GetActiveScene().name == "LevelThree")
        {
            SceneManager.LoadScene("IntroMenuScene");
        }
    }

    public void ExitButtonPressed()
    {

        Destroy(GameObject.Find("Player"));
        SceneManager.LoadScene("IntroMenuScene");
    }
    private void SpawnBoss()
    {
        SpeechManager.GetComponent<DialogueManager>().UpdateLeftText("BossTime : " + BossThisLevel.name);
        GameObject Boss = Instantiate(BossThisLevel);
        if (BossThisLevel.name == "Boss1")
        { 
        Boss.GetComponent<Boss1EldritchMoon>().Spawn(new Vector3(5, 1, 0), 0, 0);
        ActiveEnemies.Add(Boss);
        }
        else if(BossThisLevel.name == "Boss2 MushroomDoritoQueen")
        {
            Boss.GetComponent<Boss2Logic>().Spawn(new Vector3(5, 1, 0), 0, 0);
            ActiveEnemies.Add(Boss);
        }
        else if(BossThisLevel.name == "FinalBoss")
        {
            Boss.GetComponent<Boss3Logic>().Spawn(new Vector3(5, 1, 0), 0, 0);
            ActiveEnemies.Add(Boss);
        }

    }

    private void SpawnNextWave()
    {
        // if(ActiveEnemies!=null)
        //  {
        // ActiveEnemies.Free();
        // }
        SpeechManager.GetComponent<DialogueManager>().UpdateLeftText("Wave: " + ActualWave);
        if (ActiveEnemies.Count > 0)
        {


            for (int i = ActiveEnemies.Count-1; i > 0; i--)
            {
                Destroy(ActiveEnemies[i].gameObject);
                ActiveEnemies.Remove(ActiveEnemies[i]);
            }
        }
        //ActiveEnemies = new GameObject[ActualWave];
       for(int i=0;i<ActualWave;i++)
        {

            float x=Random.Range(8,12);
            float y = Random.Range(-1, 4); 
            Vector3 StartPos=new Vector3(x,y,0);

            GameObject one;

            int CHaracterCHooser = Random.Range(MinNumAllowed,MaxNumAllowed+1);

            one = Enemies[0];
            switch(CHaracterCHooser)
                {
                case 1:
                    one = Instantiate(Enemies[0]);
                    one.GetComponent<BaseEnemy>().Spawn(StartPos, -4, 0);

                    break;
                    case 2:
                    one = Instantiate(Enemies[1]);
                    one.GetComponent<BaseEnemy>().Spawn(StartPos, -4f, 0f);
                    break;
                    case 3:
                    if (ShieldSpawned < MaxShieldAllowed)
                    {
                        one = Instantiate(Enemies[2]);
                        one.GetComponent<MushroomDefender>().Spawn(StartPos, -4f, 0f);
                        ShieldSpawned++;
                    }
                    else
                    {
                        one = Instantiate(Enemies[3]);
                        one.GetComponent<BaseEnemy>().Spawn(StartPos, -3, 0f);
                    }
                    break;
                    case 4:
                    one = Instantiate(Enemies[3]);
                    one.GetComponent<BaseEnemy>().Spawn(StartPos, -3, 0f);
                    break;
                    case 5:
                    one = Instantiate(Enemies[4]);
                    one.GetComponent<FrogShammonLogicScript>().Spawn(StartPos, -3, 0f);
                    break;
                    case 6:
                    one = Instantiate(Enemies[5]);
                    one.GetComponent<BaseEnemy>().Spawn(StartPos, -3, 0f);
                    break;
                default:
                    one=new GameObject();
                    break;
            }
           

            ActiveEnemies.Add(one);
            
        }
        
    }
}
//x 8 to 13
//y -1 to -4