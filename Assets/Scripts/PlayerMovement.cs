using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rb2D;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    public bool grounded;

    void Start()
    {    

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
        
        
        
        }
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            rb2D.velocity = new Vector2(0, jumpForce);
        }
    }
}
