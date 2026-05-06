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
        // 1. 기본 속도를 가져옵니다.
        float currentSpeed = moveSpeed;

        // 2. 게임 중이라면, (현재 시간 - 게임 시작 시간)을 구해 전역적으로 얼마나 속도가 증가해야 하는지 계산합니다.
        if (GameManager.Instance != null && GameManager.Instance.State == GameState.Playing)
        {
            float elapsedTime = Time.time - GameManager.Instance.PlayStartTime;
            currentSpeed += elapsedTime * speedIncreaseRate;
        }

        // 3. 계산된 전역 속도로 이동시킵니다.
        transform.position += Vector3.left * currentSpeed * Time.deltaTime;
    }
}
