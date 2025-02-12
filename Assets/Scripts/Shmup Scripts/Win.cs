using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject credits;

    public void ShowCredits()
    {
        winScreen.SetActive(false);
        credits.SetActive(true);
    }

    public void HideCredits()
    {
        winScreen.SetActive(true);
        credits.SetActive(false);
    }
}
