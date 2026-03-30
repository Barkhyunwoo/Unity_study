using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float JumpForce;

    [Header("References")]
    public Rigidbody2D PlayerRigidBody;
    public Animator PlayerAnimator;

    private bool isGrounded = true;
    private int jumpCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount != 2)
        {
            PlayerRigidBody.AddForceY(JumpForce, ForceMode2D.Impulse);
           
            isGrounded = false;
            
            PlayerAnimator.SetInteger("state", 1);
            jumpCount++;
        }

        

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
}
