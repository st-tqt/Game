using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnTime;
    float m_spawnTime;
    int m_Score;
    bool m_isGameOver;
    UIManager m_ui;
    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScoreText("Score: " + m_Score + " ");
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameOver)
        {
            m_spawnTime = 0;
            m_ui.ShowGameOverPanel(true);
            return;
        }
        m_spawnTime -= Time.deltaTime;
        if (m_spawnTime <= 0)
        {
            SpawnObstacle();
            m_spawnTime = spawnTime;
        }
    }

    public void SpawnObstacle()
    {
        float randYPos = Random.Range(-3f, -1f);
        Vector2 spawnPos = new Vector2(11, randYPos);
        if (obstacle)
        {
            Instantiate(obstacle, spawnPos, Quaternion.identity);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void SetScore(int value)
    {
        m_Score = value;
    }
    public int GetScore()
    {
        return m_Score;
    }
    public void ScoreIncrement()
    {
        if (m_isGameOver) return;

        m_Score++;
        m_ui.SetScoreText("Score: " + m_Score + " ");
    }
    public bool IsGameOver()
    {
        return m_isGameOver;
    }
    public void SetIsGameOver(bool state)
    {
        m_isGameOver = state;
    }
}
