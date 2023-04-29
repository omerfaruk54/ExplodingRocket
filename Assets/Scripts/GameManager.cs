using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public int score = 0 , highScore;
    public TextMeshProUGUI scoreText, highScoreText;
    public GameObject playButton;
    public GameObject leaderboardPanel;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private Leaderboard leaderboard;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        playButton.SetActive(false);
        leaderboardPanel.SetActive(false);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "HIGH SCORE: " + highScore.ToString();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
           StartCoroutine(GameOver());
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    IEnumerator GameOver()
    {
        Time.timeScale = 0;
        playButton.SetActive(true);
        leaderboardPanel.SetActive(true);
        yield return leaderboard.SubmitScoreRoutine(score);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");

    }


    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = "" + score.ToString();

        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "HIGH SCORE: " + highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
        }

    }
}
