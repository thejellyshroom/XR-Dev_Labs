using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public AudioClip enemyDeathSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            SoundFXManager.instance.PlaySound(enemyDeathSound, other.transform, 1.0f);

            Destroy(gameObject);
            Destroy(other.gameObject);
            GameObject.FindFirstObjectByType<ScoreCounter>().AddScore(1);

        }
    }
}
