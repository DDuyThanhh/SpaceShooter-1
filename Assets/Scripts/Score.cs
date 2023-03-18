using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text hiScoreText;
    [SerializeField] int score;
    [SerializeField] int hiScore;

    private void OnEnable()
    {
        EventManager.onStartGame += ResetScore;
        EventManager.onStartGame += loadHiScore;
        EventManager.onPlayerDead += CheckNewHiScore;
        EventManager.onScorePoints += AddScore;
    }

    private void OnDisable()
    {
        EventManager.onStartGame -= ResetScore;
        EventManager.onStartGame -= loadHiScore;
        EventManager.onPlayerDead -= CheckNewHiScore;
        EventManager.onScorePoints -= AddScore;
    }

    private void ResetScore()
    {
        score = 0;
        DisPlayScore();
    }

    void AddScore(int amt)
    {
        score += amt;
        DisPlayScore();
    }

    void DisPlayScore()
    {
        scoreText.text = score.ToString();
    }

    void loadHiScore()
    {
        hiScore = PlayerPrefs.GetInt("hiScore", 0);
        DisPlayHighScore();
    }

    void CheckNewHiScore()
    {
        if(score > hiScore)
        {
            PlayerPrefs.SetInt("hiScore", score);
            DisPlayHighScore();
        }
    }

    void DisPlayHighScore()
    {
        hiScoreText.text = hiScore.ToString();
    }
}
