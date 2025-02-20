using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public AudioClip enemyDeathSound;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            SoundFXManager.instance.PlaySound(enemyDeathSound, other.transform, 1.0f);
            GameObject particles;

            if (other.gameObject.GetComponent<EnemyBehavior>() == null)
            {
                particles = other.gameObject.GetComponent<SecondEnemy>().getCollisionParticles();
            }
            else
            {
                particles = other.gameObject.GetComponent<EnemyBehavior>().getCollisionParticles();
            }
            // GameObject particles = other.gameObject.GetComponent<EnemyBehavior>().getCollisionParticles();


            Instantiate(particles, transform.position, Quaternion.identity);

            Destroy(gameObject);
            Destroy(other.gameObject);
            GameObject.FindFirstObjectByType<ScoreCounter>().AddScore(1);
        }
    }
}
