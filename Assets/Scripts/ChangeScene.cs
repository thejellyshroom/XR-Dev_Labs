using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public List<string> sceneNames;
    public int sceneIndex = 0;
    [SerializeField] GameObject player;

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject == this.player)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNames[sceneIndex]);
        }
    }

    private int getSceneIndex()
    {
        return sceneIndex;
    }
}
