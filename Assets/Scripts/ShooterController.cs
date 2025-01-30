using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    public Vector3 firePointOffset = new Vector3(5, 0, 0);

    private Rigidbody rb;
    public float speed = 10.0f;
    public float bulletSpeed = 50.0f;
    private float XSpeed;
    private float YSpeed;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        XSpeed = Input.GetAxis("Horizontal") * speed;
        YSpeed = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(XSpeed, YSpeed, 0);
        rb.linearVelocity = movement;

        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position + firePointOffset, firePoint.rotation);
        //dynamically add a Rigidbody and add force
        bullet.AddComponent<Rigidbody>();
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        BoxCollider collider = bullet.AddComponent<BoxCollider>();
        collider.isTrigger = true;
        bullet.AddComponent<BulletBehavior>();
        rb.useGravity = false;
        rb.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);

        DestroyBySpawnTime(bullet);
    }

    private void DestroyBySpawnTime(GameObject gameObject, float time = 5.0f)
    {
        Destroy(gameObject, time);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
    }
}
