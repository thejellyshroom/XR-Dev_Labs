using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private Quaternion enemyRotation = Quaternion.Euler(0, 270, 0);
    private float enemySpawnScale = 0.2f;
    public float spawnTime = 2f;
    private Vector3 spawnPosition;
    public float speed = 1.1f;


    private Vector2 verticalRange = new Vector2(-20, 20);

    void Start()
    {
        InvokeRepeating("Spawn", 1.0f, spawnTime);
    }

    private void Spawn()
    {
        spawnPosition = new Vector3(40, Random.Range(verticalRange.x, verticalRange.y), 0);
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, enemyRotation);
        enemy.transform.localScale = new Vector3(enemySpawnScale, enemySpawnScale, enemySpawnScale);
        enemy.GetComponent<BoxCollider>().isTrigger = true;

        //assign the tag to the enemy
        enemy.tag = "Enemy";

        float randomVerticalSpeed = Random.Range(verticalRange.x, verticalRange.y);
        float randomSpeed = Random.Range(5f, 20f);
        EnemyBehavior movementComponent = enemy.AddComponent<EnemyBehavior>();
        movementComponent.Initialize(randomSpeed, randomVerticalSpeed);
    }
}
