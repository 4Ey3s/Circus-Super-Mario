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

            //playerSr.enabled = false;
            playerMovement.enabled = false;
            Destroy(GetComponent<CapsuleCollider2D>());
            Debug.Log("Death");
            Camera.main.transform.parent = null; 
            Destroy(gameObject, 6);                                   
            StartCoroutine("ContinueTime");
            Time.timeScale = 0;
        }



    }
    IEnumerator ContinueTime()
    {
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(2);
        RestartGame();

    }

    void RestartGame()
    {
        Debug.Log("Death, restarting...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}
