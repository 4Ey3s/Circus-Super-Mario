using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;

    public SpriteRenderer playerSr;
    public PlayerMovement playerMovement;

    Rigidbody2D rb2D;


    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {           
            //animator.SetTrigger("Kuolema animaatio jos tulee");           
            playerSr.enabled = false;
            playerMovement.enabled = false;
            Destroy(GetComponent<CapsuleCollider2D>());
            Camera.main.transform.parent = null;

        }
       

    }
   


}
