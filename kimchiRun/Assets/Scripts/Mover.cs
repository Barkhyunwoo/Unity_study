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
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        moveSpeed += speedIncreaseRate * Time.deltaTime; // 매 프레임마다 속도 증가
        Debug.Log("현재 스크롤 속도: " + speedIncreaseRate);
    }
}
