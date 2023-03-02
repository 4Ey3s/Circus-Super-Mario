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
    private Rigidbody2D rb2D;
    [SerializeField]
    private float direction;
    public GameObject detectionPoint;


    private Animator animator; 


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

        /*if (Mathf.Abs(player.position.x - transform.position.x) < 2f && isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpHeight);
        }
        */
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        //animator.SetFloat("speed", Mathf.Abs(rb2D.velocity.x));


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


    private void LateUpdate()
    {
        Debug.DrawRay(detectionPoint.transform.position, Vector2.down, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(detectionPoint.transform.position, Vector2.down, 10f, groundLayer);
        if (!hit)
        {
            Jump();

        }




        Debug.DrawRay(detectionPoint.transform.position, Vector2.right * direction, Color.blue);
        RaycastHit2D hit2 = Physics2D.Raycast(detectionPoint.transform.position, new Vector2(direction, 0), groundLayer);
        if (hit2.collider != null)

        {
            Jump();

        }




    }
    public void Jump()
    {
        rb2D.AddForce(Vector2.up * jumpHeight);
        rb2D.velocity = new Vector2(rb2D.velocity.x, 2);
    }


}








