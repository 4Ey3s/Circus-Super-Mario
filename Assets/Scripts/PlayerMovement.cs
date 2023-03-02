using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rb2D;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    public bool grounded;

    AudioSource jumpSound;

    public float health;
    public float previousHealth;
    public float maxHealth;
    public Animator animator;


    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        jumpSound = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer))
        {
            grounded = true;

        }
        else
        {
            grounded = false;
        }

        transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            animator.SetBool("Run", true);


        }
        else
        {
            animator.SetBool("Run", false);
        }
        if (Input.GetButtonDown("Jump") && grounded == true)

        {
            rb2D.velocity = new Vector2(0, jumpForce);
            jumpSound.Play();
            animator.SetTrigger("Jump");


        }

        {
            if (rb2D.velocity.y < 0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

            }
            else if (rb2D.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

            }



       }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NextLevel"))
        {
           GameManager.manager.currentLevel = collision.gameObject.name;

            SceneManager.LoadScene(collision.gameObject.GetComponent<NextLevel>().LevelToLoad);
        }
    }


}
