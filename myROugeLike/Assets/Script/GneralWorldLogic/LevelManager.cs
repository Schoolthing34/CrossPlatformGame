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
        
    }
    public void StartLevel(int Level,int LevelTimer)
    {
        LevelOn = 0.00f;
        CurrentLevel = Level;
        this.LevelTimer = LevelTimer;
        CurrentWaveSPawned = 0;
        LevelOn = 0;
        ActualWave = 0;
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
                MinNumAllowed = 3;
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
                        ActiveEnemies.RemoveAt(i);
                    }
                    else if (ActiveEnemies[i].activeSelf)
                    {
                        check = false;
                    }
                    else
                    {
                        ActiveEnemies.RemoveAt(i);
                    }
                }
            }
           if(check)
            {
                WaveDead = true;
                if(BossSpawned)
                {
                    SceneManager.LoadScene("IntroMenuScene");
                   // Application.LoadLevel("IntroMenuScene");
                }
            }

            
            
            LevelOn += Time.deltaTime;
        }
    }

    private void SpawnBoss()
    {
        GameObject Boss=Instantiate(BossThisLevel);
        Boss.GetComponent<Boss1EldritchMoon>().Spawn(new Vector3(5, 1, 0), 0, 0);
        ActiveEnemies.Add(Boss);
    }

    private void SpawnNextWave()
    {
        // if(ActiveEnemies!=null)
        //  {
        // ActiveEnemies.Free();
        // }

        if (ActiveEnemies.Count > 0)
        {


            for (int i = ActiveEnemies.Count; i > 0; i--)
            {
                Destroy(ActiveEnemies[i]);
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
                    one.GetComponent<BaseEnemy>().Spawn(StartPos, 4, 0);

                    break;
                    case 2:
                    one = Instantiate(Enemies[1]);
                    one.GetComponent<BaseEnemy>().Spawn(StartPos, -4f, 0f);
                    break;
                    case 3:
                    one = Instantiate(Enemies[2]);
                    one.GetComponent<MushroomDefender>().Spawn(StartPos, -4f, 0f);
                    break;
                    case 4:
                    one = Instantiate(Enemies[3]);
                    one.GetComponent<BaseEnemy>().Spawn(StartPos, -100f, 0f);
                    break;
                    case 5:
                    break;
                    case 6:
                    break;
                default:
                    one=new GameObject();
                    break;
            }
            /*if (ActualWave%2==0)
            {
                 one= Instantiate(Enemies[0]);
                one.GetComponent<BaseEnemy>().Spawn(StartPos, 4, 0);
            }
            else
            {
                 one = Instantiate(Enemies[1]);
                one.GetComponent<BaseEnemy>().Spawn(StartPos, -4f, 0f);
            }*/


            ActiveEnemies.Add(one);
            // GameObject one= Instantiate(Enemies[0]);
           // Debug.Log(Enemies[0].name);
           // Debug.Log(Enemies[1].name);
           // GameObject two= Instantiate(Enemies[1],this.transform);

           // Debug.Log(two.name + " has component? " + two.GetComponent<MoonLogicComponant>()==null);
           // Debug.Log("the vector is " + StartPos);
           // one.GetComponent<KamakaziEnemyLogicUnity>().Spawn(StartPos,4,0);
           // two.GetComponent<BaseEnemy>().Spawn(StartPos, -4f, 0f);
          //  ActiveEnemies[i] = two;
          // ActiveEnemies[i *2  ] = one;
        }
        
    }
}
//x 8 to 13
//y -1 to -4