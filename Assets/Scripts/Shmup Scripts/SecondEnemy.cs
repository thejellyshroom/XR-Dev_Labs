using UnityEngine;

public class SecondEnemy : MonoBehaviour
{
    private GameObject collisionParticles;

    private float horizontalSpeed;
    private float verticalSpeed;

    private Vector2 verticalBounds = new Vector2(-20, 20);
    private float destroyBoundaryX = -40f;

    private void Start()
    {
        EnemyBehavior enemyBehavior = FindFirstObjectByType<EnemyBehavior>();
        collisionParticles = enemyBehavior.getCollisionParticles();
    }

    public void Initialize(float horizontalSpeed)
    {
        this.horizontalSpeed = horizontalSpeed;
        this.verticalSpeed = 0f;
    }

    void Update()
    {
        transform.position += Vector3.left * horizontalSpeed * Time.deltaTime;
        transform.position += Vector3.up * verticalSpeed * Time.deltaTime;

        if (transform.position.y < verticalBounds.x || transform.position.y > verticalBounds.y)
        {
            verticalSpeed = -verticalSpeed; // Reverse direction if out of bounds
        }

        if (transform.position.x < destroyBoundaryX)
        {
            Destroy(gameObject);
            GameObject.FindFirstObjectByType<ScoreCounter>().AddScore(1);
        }
    }

    public GameObject getCollisionParticles()
    {
        return collisionParticles;
    }
}
