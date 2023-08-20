using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    private int score = 0;
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text finalScoreText;
    public GameObject gameOverScreen;


    [ContextMenu("increase score")]
    public void addScore(int scoreToAdd, bool playerIsAlive)
    {
        if (playerIsAlive)
        {
            score += scoreToAdd;
            scoreText.text= score.ToString();
            Debug.Log("new score"+ score.ToString());
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void gameOver()
    {
        finalScoreText.text += score.ToString();
        gameOverScreen.SetActive(true);

    }
}
