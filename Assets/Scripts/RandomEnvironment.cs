using UnityEngine;

public class RandomEnvironment : MonoBehaviour
{
    // randomly generates character from a list of prefabs in a set location
    //randomly generates environment from a list of prefabs in a series of location points
    [SerializeField] GameObject[] characters;
    private Vector3 characterLocation = new Vector3(0, 0.6f, 1);

    [SerializeField] GameObject[] environmentProps;
    public Vector3[] environmentLocations;

    // call the randomizer once every second
    void Start()
    {
        InvokeRepeating("Randomize", 0, 1);
    }


    // randomly generate a character from a list of prefabs in a set location 
    // randomly generate environment from a list of prefabs in a series of location points
    private void Randomize()
    {
        // randomly generate a character from a list of prefabs in a set location
        int characterIndex = Random.Range(0, characters.Length);
        GameObject character = Instantiate(characters[characterIndex], characterLocation, Quaternion.identity);

        // randomly generate environment from a list of prefabs in a series of location points
        for (int i = 0; i < environmentLocations.Length; i++)
        {
            int environmentIndex = Random.Range(0, environmentProps.Length);
            // set pivot point of environment prop to be at bottom
            Vector3 propSize = environmentProps[environmentIndex].GetComponent<Renderer>().bounds.size;
            Vector3 propPosition = environmentLocations[i];
            propPosition.y += propSize.y / 2;

            GameObject environmentProp = Instantiate(environmentProps[environmentIndex], propPosition, Quaternion.identity);
            Destroy(environmentProp, 1);

        }

        Destroy(character, 1);
    }
}
