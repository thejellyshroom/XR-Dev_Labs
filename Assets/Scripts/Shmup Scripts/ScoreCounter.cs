using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEditor;
using Unity.VisualScripting;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject winUI;

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
            if (sceneIndex == 0)
            {
                winUI.SetActive(true);
                Time.timeScale = 0;
                return;
            }
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNames[sceneIndex]);
        }
    }

    //reload this scene
    public void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        //freeze game
        Time.timeScale = 0;
    }
}
