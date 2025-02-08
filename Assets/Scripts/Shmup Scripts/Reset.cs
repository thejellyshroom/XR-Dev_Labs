using UnityEngine;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        // Get the Button component attached to this GameObject
        button = GetComponent<Button>();

        if (button == null)
        {
            Debug.LogError("ButtonMusicReset: No Button component found on this GameObject!");
            return;
        }

        // Add a listener to the button click event
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        // Find the MusicManager in the scene
        MusicManager musicManager = FindFirstObjectByType<MusicManager>();

        if (musicManager != null)
        {
            musicManager.ResetMusic();
        }
        else
        {
            Debug.LogError("ButtonMusicReset: MusicManager not found in the scene!");
        }
    }
}
