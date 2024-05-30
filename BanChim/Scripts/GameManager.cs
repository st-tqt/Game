using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float spawnTime;
    public Bird[] birdsPrefabs;
    public int timeLimit;

    int m_curTimeLimit;
    int m_birdKilled;
    bool m_isGameover;

    public int BirdKilled { get => m_birdKilled; set => m_birdKilled = value; }
    public bool IsGameover { get => m_isGameover; set => m_isGameover = value; }

    public override void Awake()
    {
        MakeSingleton(false);

        m_curTimeLimit = timeLimit;
    }

    public override void Start()
    {
        GameUIManager.Ins.ShowGameGui(false);
        GameUIManager.Ins.UpdateKilledCounting(m_birdKilled);
    }

    public void PlayGame()
    {
        StartCoroutine(GameSpawn());

        StartCoroutine(TimeCountDown());

        GameUIManager.Ins.ShowGameGui(true);
    }

    IEnumerator TimeCountDown()
    {
        while (m_curTimeLimit > 0)
        {
            yield return new WaitForSeconds(1f);
            m_curTimeLimit--;

            if (m_curTimeLimit <= 0)
            {
                m_isGameover = true;
                Prefs.bestScore = m_birdKilled;    

                GameUIManager.Ins.gameDialog.UpdateDialog("YOUR BEST", "BEST KILLED : x" + Prefs.bestScore);
                GameUIManager.Ins.gameDialog.Show(true);
                GameUIManager.Ins.CurDialog = GameUIManager.Ins.gameDialog;
            }

            GameUIManager.Ins.UpdateTimer(IntToTime(m_curTimeLimit));
        }
    }

    IEnumerator GameSpawn()
    {
        while (!m_isGameover)
        {
            SpawnBird();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    void SpawnBird()
    {
        Vector3 spawnPos = Vector3.zero;
        float randCheck = Random.Range(0f, 1f);

        if (randCheck >= 0.5f)
        {
            spawnPos = new Vector3(10, Random.Range(-1.5f, 4f), 0);
        }
        else 
        {
            spawnPos = new Vector3(-10, Random.Range(-1.5f, 4f), 0);
        }

        if (birdsPrefabs != null && birdsPrefabs.Length > 0)
        {
            int randIdx = Random.Range(0, birdsPrefabs.Length);

            if (birdsPrefabs[randIdx] != null)
            {
                Bird birdClone = Instantiate(birdsPrefabs[randIdx], spawnPos, Quaternion.identity);
            }
        }
    }

    string IntToTime(int time)
    {
        float minutes = Mathf.Floor(time / 60);
        float seconds = Mathf.RoundToInt(time % 60);

        return minutes.ToString("00") + " : " + seconds.ToString("00");
    }
}
