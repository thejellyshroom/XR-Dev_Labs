using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    [SerializeField] AudioClip gameOver;
    [SerializeField] AudioClip gameMusic;
    // do not destroy on scene change
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public AudioClip GetGameOverMusic()
    {
        return gameOver;
    }

    public void ResetMusic()
    {
        AudioSource audioSource = FindFirstObjectByType<MusicManager>().gameObject.GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("No AudioSource found on MusicManager.");
            return;
        }

        // Force stop before resetting the music
        audioSource.Stop();

        // Assign and restart the game music
        audioSource.clip = gameMusic;

        // Ensure the audio source is enabled before playing
        if (!audioSource.enabled)
        {
            Debug.LogError("AudioSource was disabled! Enabling it now.");
            audioSource.enabled = true;
        }

        audioSource.loop = true;
        audioSource.Play();

        Debug.Log("Game music restarted.");
    }

}
