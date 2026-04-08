using UnityEngine;

public class Spawer : MonoBehaviour
{
    [Header("Settings")]
    public float minSpawnDelay;
    public float maxSpawnDelay;

    [Header("Referenece")]
    public GameObject[] gameObjects;

    

    void OnEnable() 
    {
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));

    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void Spawn()
    {
        var randomObject = gameObjects[Random.Range(0, gameObjects.Length)];
        Instantiate(randomObject, transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
}
