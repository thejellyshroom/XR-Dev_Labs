using UnityEngine;

public class MarbleController : MonoBehaviour
{
    private GameObject marble;
    public float speed = 10.0f;
    private float horizontalMvt;
    private float verticalMvt;

    void Start()
    {
        marble = this.gameObject;
    }

    void Update()
    {
        horizontalMvt = Input.GetKey(KeyCode.RightArrow) ? 1 : Input.GetKey(KeyCode.LeftArrow) ? -1 : 0;
        verticalMvt = Input.GetKey(KeyCode.UpArrow) ? 1 : Input.GetKey(KeyCode.DownArrow) ? -1 : 0;

        Vector3 movement = new Vector3(horizontalMvt, 0.0f, verticalMvt);
        // marble.transform.position += movement * speed * Time.deltaTime;
        marble.GetComponent<Rigidbody>().AddForce(movement * speed);
    }




}
