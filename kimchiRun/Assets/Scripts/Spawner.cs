using UnityEngine;

public class Spawer : MonoBehaviour
{
    [Header("Settings")]
    public float minSpawnDelay;
    public float maxSpawnDelay;

    public float speedIncreaseRate = 0.001f;


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

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.State == GameState.Playing)
        {
            // 태그가 "Enemy"인 스포너일 때만 딜레이를 감소시킵니다.
            if (gameObject.CompareTag("enemy") || gameObject.CompareTag("building"))
            {
                // Time.deltaTime을 곱해 매 초마다 speedIncreaseRate만큼 일정하게 줄어들도록 합니다.
                if(minSpawnDelay > 0.5f){
                    minSpawnDelay -= speedIncreaseRate * Time.deltaTime;
                    maxSpawnDelay -= speedIncreaseRate * Time.deltaTime;
                }
                else if(maxSpawnDelay > 1f){
                    maxSpawnDelay -= speedIncreaseRate * Time.deltaTime;
                }
            }
        }
    }
}
