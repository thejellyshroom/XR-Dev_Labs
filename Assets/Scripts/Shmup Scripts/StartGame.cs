using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject title;
    [SerializeField] GameObject scoreCounter;
    void Start()
    {
        Time.timeScale = 0;
    }

    public void PlayPressed()
    {
        Time.timeScale = 1;
        title.SetActive(false);
        scoreCounter.SetActive(true);
    }
}
