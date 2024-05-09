using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Ball;
    public float spawnTime;
    float m_spawnTime;
    int m_score;
    bool m_isGameover = false;
    UIManager m_ui;
    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScoreText("Score: " + m_score + " ");
    }

    // Update is called once per frame
    void Update()
    {
        m_spawnTime -= Time.deltaTime;

        if (m_isGameover)
        {
            m_spawnTime = 0;
            m_ui.ShowGameOverPanel(true);
            return;
        }

        if (m_spawnTime <= 0)
        {
            SpawnBall();
            m_spawnTime = spawnTime - (float)m_score/50;
        }
    }
    public void SpawnBall()
    {
        Vector2 SpawnPos = new Vector2(Random.Range(-11, 11), 6);
        if (Ball)
        {
            Instantiate(Ball, SpawnPos, Quaternion.identity);
        }
    }

    public void Replay()
    {
        m_score = 0;
        m_isGameover = false;
        m_ui.SetScoreText("Score: " + m_score + " ");
        m_ui.ShowGameOverPanel(false);
    }

    public void SetScore(int value)
    {
        m_score = value;
    }
    public int GetScore()
    {
        return m_score;
    }
    public void InCrementScore()
    {
        m_score++;
        m_ui.SetScoreText("Score: " + m_score + " ");
    }
    public bool IsGameover()
    {
        return m_isGameover;
    }
    public void SetGameoverState(bool state)
    {
        m_isGameover = state;
    }
}
