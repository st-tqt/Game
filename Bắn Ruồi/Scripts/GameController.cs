using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float spawnTime;
    public GameObject enemy;
    float m_spawnTime;
    int m_Score;
    bool m_isGameOver;
    UIManager m_ui;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScoreText("Score " + m_Score + " ");
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
            SpawnEnemy();
            m_spawnTime = spawnTime - (float)m_Score/100;
        }
    }

    public void SpawnEnemy()
    {
        float RandXpos = Random.Range(-11f, 11f);

        Vector2 spawnPos = new Vector2(RandXpos, 6);

        if (enemy)
        {
            Instantiate(enemy, spawnPos, Quaternion.identity);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void ScoreIncrement()
    {
        if (m_isGameOver == false) m_Score++;
        m_ui.SetScoreText("Score " + m_Score + " ");
    }
    public int GetScore()
    {
        return m_Score;
    }
    public void SetGameOverState(bool state)
    {
        m_isGameOver = state;
    }
    public bool IsGameOver()
    {
        return m_isGameOver;
    }
}
