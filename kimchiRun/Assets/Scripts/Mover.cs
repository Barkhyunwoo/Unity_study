using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 1f;
    public float speedIncreaseRate = 0.5f; // 초당 증가할 속도량

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentSpeed = moveSpeed;

        if (GameManager.Instance != null && GameManager.Instance.State == GameState.Playing)
        {
            float elapsedTime = Time.time - GameManager.Instance.PlayStartTime;
            currentSpeed += elapsedTime * speedIncreaseRate;
        }

        transform.position += Vector3.left * currentSpeed * Time.deltaTime;
    }
}
