using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    Transform Player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float jumpForce;


    Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, Player.position);
        Debug.Log("distToPlayer:" + distToPlayer);

        if (distToPlayer < agroRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }

    }


    void ChasePlayer()
    {
        if (transform.position.x < Player.position.x)
        {
            rb2D.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            if (transform.position.x > Player.position.x)
                rb2D.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
        }

        if (transform.position.y < Player.position.y)
        {
            rb2D.velocity = new Vector2(0, jumpForce);
        }

    }

    void StopChasingPlayer()
    {
        rb2D.velocity = Vector2.zero;
    }


}
