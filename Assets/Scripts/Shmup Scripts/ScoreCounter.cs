using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEditor;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject gameOverUI;

    public int targetScore = 10;
    private int score = 0;

    public List<string> sceneNames;
    public int sceneIndex = 0;

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score.ToString();
    }

    //change to new scene if score is 10
    void Update()
    {
        if (score == targetScore)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNames[sceneIndex]);

        }
    }

    //reload this scene
    public void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        //freeze game
        Time.timeScale = 0;
    }
}
