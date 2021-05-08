using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    public int maxHealth = 1;
    public int maxShieldHealth = 1;
    int currentHealth;
    int currentShieldHealth;
    public bool imRed;
    public bool imBlue;
    public int color;
    public Material red;
    public Material blue;
    public GameObject model;
    public GameObject shield;
    public GameObject shieldR;
    public GameObject shieldB;

    void Start()
    {
        currentHealth = maxHealth;
        currentShieldHealth = maxShieldHealth;
        DefineColor();
        DefineShieldColor();
    }

    void Die()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void DefineColor()
    {
        color = Random.Range(0, 2);
        //print(color);
        if (color == 0)
        {
            imRed = false;
            imBlue = true;
            gameObject.layer = LayerMask.NameToLayer("Azul");
            model.GetComponent<SkinnedMeshRenderer>().material = blue;
        }
        else
        {
            imRed = true;
            imBlue = false;
            gameObject.layer = LayerMask.NameToLayer("Rojo");
            model.GetComponent<SkinnedMeshRenderer>().material = red;
        }
    }
    public void DefineShieldColor()
    {
        color = Random.Range(0, 2);
        //print(color);
        if (color == 0)
        {
            shield.gameObject.layer = LayerMask.NameToLayer("Azul");
            shieldB.SetActive(true);
            shieldR.SetActive(false);
        }
        else
        {
            shield.gameObject.layer = LayerMask.NameToLayer("Rojo");
            shieldB.SetActive(false);
            shieldR.SetActive(true);
        }
    }

}