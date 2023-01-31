using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   public PlayerHealth playerHealth;
    public int damage = 1;
    public Transform player;
    public float moveSpeed = 2f;
    public float jumpHeight = 5f;
    public bool facingRight = false;
    public LayerMask groundLayer;
    public Transform groundCheck;
    private bool isGrounded;
    private Rigidbody2D rb;
    //private Animator anim; 

    public
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }


    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);


        if (player.position.x > transform.position.x && facingRight)
        {
            Flip();
        }
        else if (player.position.x < transform.position.x && !facingRight)
        {
            Flip();
        }

        if (Mathf.Abs(player.position.x - transform.position.x) < 2f && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        //anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }

        
    }





