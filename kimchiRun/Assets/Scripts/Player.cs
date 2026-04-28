using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float JumpForce;

    [Header("References")]
    public Rigidbody2D PlayerRigidBody;
    public Animator PlayerAnimator;
    public SpriteRenderer PlayerSpriteRenderer;

    private bool isGrounded = true;
    private int jumpCount = 0;

    
    public bool isInvincible = false;

    public BoxCollider2D PlayerCollider;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount != 2)
        {
            PlayerRigidBody.linearVelocity = new Vector2(PlayerRigidBody.linearVelocity.x, 0f);
            PlayerRigidBody.AddForceY(JumpForce, ForceMode2D.Impulse);
           
            isGrounded = false;
            
            PlayerAnimator.SetInteger("state", 1);
            jumpCount++;
        }

        

    }

    public void KillPlayer()
    {
        PlayerCollider.enabled = false;
        PlayerAnimator.enabled = false;
        PlayerRigidBody.AddForceY(JumpForce, ForceMode2D.Impulse);
    }

    void Hit()
    {
        GameManager.Instance.Lives -= 1;
        PlayerSpriteRenderer.color = Color.red;

        CancelInvoke("Normal");
        Invoke("Normal", 0.5f);

    }

    void Normal()
    {
        PlayerSpriteRenderer.color = Color.white;
    }

    void Heal()
    {
        GameManager.Instance.Lives = Mathf.Min(3, GameManager.Instance.Lives + 1);
    }

    void StartInvincible()
    {
        isInvincible = true;
        Color playerColor = PlayerSpriteRenderer.color;
        playerColor.a = 0.5f;
        PlayerSpriteRenderer.color = playerColor;
        Invoke("StopInvincible", 5f);
    }

    void StopInvincible()
    {
        Color playerColor = PlayerSpriteRenderer.color;
        playerColor.a = 1f;
        PlayerSpriteRenderer.color = playerColor;
        isInvincible = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Platform")
        {
            if (!isGrounded)
            {
                PlayerAnimator.SetInteger("state", 2);
            }
            isGrounded = true;
            jumpCount = 0;
            
        }


    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "enemy")
        {
            if (!isInvincible)
            {
                Destroy(collider.gameObject);
                Hit();
            }
            
            
        }
        else if (collider.gameObject.tag == "food")
        {
            Destroy(collider.gameObject);
            Heal();
        }
        else if (collider .gameObject.tag == "golden")
        {
            Destroy(collider.gameObject);
            StartInvincible();
        }
    }
}
