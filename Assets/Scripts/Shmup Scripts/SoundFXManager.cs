using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    [SerializeField] private AudioSource soundObj;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySound(AudioClip clip, Transform spawn, float volume)
    {
        AudioSource audioSource = Instantiate(soundObj, spawn.position, Quaternion.identity);
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = clip.length;
        Destroy(audioSource.gameObject, clip.length);
    }
}
