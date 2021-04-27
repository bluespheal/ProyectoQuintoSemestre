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
            gameObject.layer = LayerMask.NameToLayer("Color1");
            model.GetComponent<SkinnedMeshRenderer>().material = blue;
        }
        else
        {
            imRed = true;
            imBlue = false;
            gameObject.layer = LayerMask.NameToLayer("Color2");
            model.GetComponent<SkinnedMeshRenderer>().material = red;
        }
    }
    public void DefineShieldColor()
    {
        color = Random.Range(0, 2);
        //print(color);
        if (color == 0)
        {
            gameObject.layer = LayerMask.NameToLayer("Color1");
            shield.GetComponent<MeshRenderer>().material = blue;
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Color2");
            shield.GetComponent<MeshRenderer>().material = red;
        }
    }

}