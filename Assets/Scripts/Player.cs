using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int apples;
    public float MoveSpeed = 5f;
    public float JumpSpeed = 10f;
    public Transform GroundCheck;
    public float GroundCheckRadius = 0.2f;
    public LayerMask GroundLayer;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    public int extrajumpsvalue = 1;
    public int extrajumps;
    public int health = 100;
    private SpriteRenderer spriteRenderer;
    public Image healthImage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if(isGrounded)
        {
            extrajumps = extrajumpsvalue;
        }
        float moveinput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveinput * MoveSpeed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpSpeed);
        }
        else if(extrajumps > 0 ) 
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpSpeed);
                extrajumps--;
            }
        }
        Setanimation(moveinput);
        
        healthImage.fillAmount = health / 100f;
    }
 private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, GroundLayer);
    }
    private void Setanimation(float moveinput)
    {
        if (isGrounded)
        {
            if(moveinput == 0)
            {
                animator.Play("Player_Idle");
            }
            else
            {
                animator.Play("Player_Run");
            }
        }
        else
        {
            if(rb.linearVelocity.y > 0)
            {
                animator.Play("Player_Jump");
            }
            else
            { 
                animator.Play("Player_fall");
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Damage"))
        {
          
            health -= 25;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpSpeed);
            StartCoroutine(FlashRed());

            if(health <= 0) { Die();
        }
    }}
    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
     spriteRenderer.color = Color.white;
    }
    private void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene"); }
    }
