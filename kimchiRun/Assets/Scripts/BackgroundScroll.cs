using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{

    [Header("Setting")]
    [Tooltip("How fast should the texture scroll?")]
    public float scrollSpeed;
    public float IncreaseSpeed = 0.01f;

    [Header("References")]
    public MeshRenderer meshRenderer;

    private float currentSpeed; // 현재 적용 중인 스크롤 속도

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 시작할 때 인스펙터에 설정한 기본 속도를 저장해둡니다.
        currentSpeed = scrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // GameManager가 존재하는지 먼저 확인
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.State == GameState.Intro)
            {
                // 게임 시작 전: 속도 증가 없이 기본 속도(scrollSpeed)로만 이동
                currentSpeed = scrollSpeed;
            }
            else if (GameManager.Instance.State == GameState.Playing)
            {
                // 게임 중: 매 프레임마다 속도 증가
                currentSpeed += IncreaseSpeed * Time.deltaTime;
            }
            else if (GameManager.Instance.State == GameState.Dead)
            {
                // 게임 오버: 스크롤 속도를 0으로 초기화 (배경 멈춤)
                currentSpeed = 0f;
            }
        }
        else
        {
            // 만약 씬에 GameManager가 없다면 기본적으로 속도가 증가하도록 처리
            currentSpeed += IncreaseSpeed * Time.deltaTime;
        }

        // 계산된 currentSpeed를 바탕으로 배경 텍스처를 스크롤합니다.
        meshRenderer.material.mainTextureOffset += new Vector2(currentSpeed * Time.deltaTime, 0);
    }
}
