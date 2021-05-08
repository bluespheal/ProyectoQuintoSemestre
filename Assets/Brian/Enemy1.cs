using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public int maxHealth = 1;
    int currentHealth;
    public bool imRed;
    public bool imBlue;
    public int color;
    public Material red;
    public Material blue;
    public GameObject model;

    void Start()
    {
        currentHealth = maxHealth;
        DefineColor();
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
    public void DefineColor()
    {
        color = Random.Range(0, 2);
        //print(color);
        if(color == 0)
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

    private void OnCollisionEnter(Collision collision)
    {

        print("Pegame");
        if(collision.gameObject.CompareTag("Bate"))
        {
            Destroy(this);
        }
    }

}