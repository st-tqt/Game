using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ScoreText;
    public GameObject gameOverPanel;
    public void SetScoreText(string txt)
    {
        if (ScoreText)
        {
            ScoreText.text = txt;
        }
    }

    public void ShowGameOverPanel(bool isShow)
    {
        if (gameOverPanel)
        {
            gameOverPanel.SetActive(isShow);
        }
    }
}
