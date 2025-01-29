using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    float Yoffset = 0.5f;
    float Zoffset = -1f;
    private Vector3 offsetVector;
    void Start()
    {
        offsetVector = new Vector3(0, Yoffset, Zoffset);
    }

    void Update()
    {
        transform.position = player.transform.position + offsetVector;

    }
}
