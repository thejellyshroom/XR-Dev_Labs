using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    [SerializeField] private GameObject textObject;
    private TMPro.TextMeshProUGUI text;
    void Start()
    {
        text = textObject.GetComponent<TMPro.TextMeshProUGUI>();
        text.text = "Hello World!";
    }

    //on any click, change text
    //canvas uses button component to call method
    public void ChangeText()
    {
        switch (text.text)
        {
            case "Hello World!":
                text.text = "Goodbye World!";
                break;
            case "Goodbye World!":
                text.text = "Hello World!";
                break;
        }
    }

}
