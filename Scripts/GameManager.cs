using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public Bird[] birdPrefabs;
    public float spawnTime;
    public int timeLimit;



    bool m_isGameOver;
    int m_curTimeLimit;
    int m_birdKilled;

    public bool IsGameOver { get => m_isGameOver; set => m_isGameOver = value; }
    public int BirdKilled { get => m_birdKilled; set => m_birdKilled = value; }

    public override void Awake()
    {
        MakeSingleton(false);
        m_curTimeLimit = timeLimit;
    }

    public override void Start()
    {
        StartCoroutine(GameSpawn());
        StartCoroutine(TimeCountDown());
        
       

    }
    IEnumerator GameSpawn()
    {
        while (!m_isGameOver)
        {
            SpawnBird();

            yield return new WaitForSeconds(spawnTime); // doi khoang thoi spawnTime
        }
    }
    
    IEnumerator TimeCountDown()
    {
        while(m_curTimeLimit >= 0)
        {
            
            yield return new WaitForSeconds(1);
            m_curTimeLimit--;
            if (m_curTimeLimit <= 0)
            {
                m_isGameOver = true;
            }
        }
    }

    void SpawnBird()
    {

        Vector3 spawnPos = Vector3.zero;

        float randCheck = Random.Range(0f, 1f);

        if (randCheck >= 0.5f)
        {
            spawnPos = new Vector3(12, Random.Range(3f, -3f));
        }
        else
        {
            spawnPos = new Vector3(-12, Random.Range(3f, -3f));
        }
        if (birdPrefabs != null && birdPrefabs.Length >= 0)
        {
            int randIdx = Random.Range(0, birdPrefabs.Length);
            if (birdPrefabs[randIdx] != null)
            {
                Instantiate(birdPrefabs[randIdx], spawnPos, Quaternion.identity);
            }
        }
    }

}
