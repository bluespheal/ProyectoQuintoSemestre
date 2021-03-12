using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public int maxHealth = 1;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    void Die()
    {

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }
}
