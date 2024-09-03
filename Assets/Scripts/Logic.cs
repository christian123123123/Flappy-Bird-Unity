using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
    public Text score;
    public int playerScore = 0;
    public int highScores;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public GameObject gameOverLogo;
    public AudioSource audioSource;

    public void addScore(int scoreToAdd) 
    {
        playerScore += scoreToAdd;
        score.text = playerScore.ToString();
        audioSource.Play();

        if (playerScore > highScores)
        {
            highScores = playerScore;
            PlayerPrefs.SetInt("HighScore", highScores);
            PlayerPrefs.Save();
            Debug.Log("New HighScore: " + highScores);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        highScores = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = highScores.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        gameOverLogo.SetActive(true);
    }
    public void quit()
    {
        Application.Quit();
    }
}
