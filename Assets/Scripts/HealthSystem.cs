using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    

    public Sprite emptyHeart;
    public Sprite fullhearts;
    public Image[] Hearts;

    public PlayerHealth playerHealth;

    void Start()
    {
        
    }

    void Update()
    {
        GameManager.manager.health = playerHealth.health;
        GameManager.manager.maxHealth = playerHealth.maxHealth;

        for (int i = 0; i <Hearts.Length; i++)
        {
            if (i < GameManager.manager.health)
            {
                Hearts[i].sprite = fullhearts;
            }
            else
            {
                Hearts[i].sprite = emptyHeart;
            }
            if (i < GameManager.manager.maxHealth)
            {
                Hearts[i].enabled = true;
            }
            else
            {
                Hearts[i].enabled =false;   
            }
        }
    }
}