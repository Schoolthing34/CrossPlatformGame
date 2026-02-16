using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> ActiveEnemies=new List<GameObject>();
    public GameObject[] Enemies;
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
    float countingFloat;
    private void Start()
    {
        StartLevel(1,180);
    }
    public void StartLevel(int Level,int LevelTimer)
    {
        LevelOn = 0.00f;
        CurrentLevel = Level;
        this.LevelTimer = LevelTimer;
        CurrentWaveSPawned = 0;
        LevelOn = 0;
        ActualWave = 1;
        WaveDead = true;
        BossSpawned = false;
        switch(CurrentLevel)
            {
            case 1:
                WaveTimer = 1;
                WaveAmount = 10;
                



                break;
            case 2:
                break;
            case 3:
                break;
            case 0:
                break;

        }
        WaveOn = true;
    }




    private void Update()
    {
        
        if(WaveOn)
        {
            if (ActualWave < CurrentWaveSPawned && (WaveDead))
            {
                WaveDead = false;
                ActualWave++;
                SpawnNextWave();
            }
            else if ((ActualWave == CurrentWaveSPawned) && (BossSpawned))
            {
                SpawnBoss();
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
                for (int i = 0; i < ActiveEnemies.Count; i++)
                {
                    //Debug.Log(ActiveEnemies[i] == null);
                    if (ActiveEnemies[i].activeSelf)
                    {
                        check = false;
                    }
                }
            }
           if(check)
            {
                WaveDead = true;
            }

            
            
            LevelOn += Time.deltaTime;
        }
    }

    private void SpawnBoss()
    {
        throw new NotImplementedException();
    }

    private void SpawnNextWave()
    {
        // if(ActiveEnemies!=null)
        //  {
        // ActiveEnemies.Free();
        // }

        if (ActiveEnemies.Count > 0)
        {


            for (int i = 0; i < ActiveEnemies.Count; i++)
            {
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

            if (ActualWave%2==0)
            {
                 one= Instantiate(Enemies[0]);
                one.GetComponent<BaseEnemy>().Spawn(StartPos, 4, 0);
            }
            else
            {
                 one = Instantiate(Enemies[1]);
                one.GetComponent<BaseEnemy>().Spawn(StartPos, -4f, 0f);
            }


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