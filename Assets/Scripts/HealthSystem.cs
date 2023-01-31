using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public Sprite emptyHeart;
    public Sprite fullhearts;
    public Image[] Hearts;

    public PlayerHealth playerHealth;

    void Start()
    {
        
    }

    void Update()
    {
        health = playerHealth.health;
        maxHealth = playerHealth.maxHealth;

        for (int i = 0; i <Hearts.Length; i++)
        {
            if (i < health)
            {
                Hearts[i].sprite = fullhearts;
            }
            else
            {
                Hearts[i].sprite = emptyHeart;
            }
            if (i < maxHealth)
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