using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    private float horizontalSpeed;
    private float verticalSpeed;

    private Vector2 verticalBounds = new Vector2(-20, 20);
    private float destroyBoundaryX = -40f;

    public void Initialize(float horizontalSpeed, float verticalSpeed)
    {
        this.horizontalSpeed = horizontalSpeed;
        this.verticalSpeed = verticalSpeed;
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
}
