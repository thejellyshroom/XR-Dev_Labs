using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject collisionParticles;
    [SerializeField] AudioClip shootSound;
    [SerializeField] AudioClip enemyDeathSound;
    [SerializeField] private AudioClip playerDeathSound;

    public Vector3 firePointOffset = new Vector3(5, 0, 0);

    private Rigidbody rb;
    public float speed = 10.0f;
    public float bulletSpeed = 50.0f;
    private float XSpeed;
    private float YSpeed;

    private Vector2 verticalRange = new Vector2(-20, 20);


    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        this.transform.position = new Vector3(-24.9f, 0, 0);
        this.transform.rotation = Quaternion.Euler(0, 90, 0);
        this.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
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

        if (transform.position.y > verticalRange.y)
        {
            transform.position = new Vector3(transform.position.x, verticalRange.y, transform.position.z);
        }
        else if (transform.position.y < verticalRange.x)
        {
            transform.position = new Vector3(transform.position.x, verticalRange.x, transform.position.z);
        }
    }

    private void Shoot()
    {
        SoundFXManager.instance.PlaySound(shootSound, firePoint, 1.0f);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position + firePointOffset, firePoint.rotation);
        //dynamically add a Rigidbody and add force
        bullet.AddComponent<Rigidbody>();
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        BoxCollider collider = bullet.AddComponent<BoxCollider>();
        collider.isTrigger = true;
        bullet.AddComponent<BulletBehavior>().enemyDeathSound = enemyDeathSound;

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
            Instantiate(collisionParticles, transform.position, Quaternion.identity);
            SoundFXManager.instance.PlaySound(playerDeathSound, transform, 1.0f);

            //set audio resource to new audio clip after game over is called
            PlayGameOverMusic();
            //2 second delay to call gameover
            FindFirstObjectByType<ScoreCounter>().Invoke("GameOver", 1.0f);
            Destroy(gameObject);


        }
    }

    private void PlayGameOverMusic()
    {
        MusicManager.instance.GetComponent<AudioSource>().clip = MusicManager.instance.GetGameOverMusic();
        MusicManager.instance.GetComponent<AudioSource>().Play();
        MusicManager.instance.GetComponent<AudioSource>().loop = false;
    }


}
