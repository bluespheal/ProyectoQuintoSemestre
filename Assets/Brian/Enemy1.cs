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
    public Material eyes;
    public Material[] newMaterials;
    public GameObject model;

    string deadTag;
    public DisolbingController ControlParticulas;

    void Start()
    {
        newMaterials = new Material[2];
        currentHealth = maxHealth;
        DefineColor();
    }
    void Die()
    {
        this.ControlParticulas.LamarDisolve();
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
        Debug.Log("Entre a Color");
        color = Random.Range(0, 2);
        //print(color);
        if(color == 0)
        {
            deadTag = "bateAzul";
            newMaterials[0] = eyes;
            newMaterials[1] = blue;
            imRed = false;
            imBlue = true;
            model.GetComponent<SkinnedMeshRenderer>().materials = newMaterials;
            gameObject.layer = LayerMask.NameToLayer("Azul");
        }
        else
        {
            deadTag = "bateRojo";
            newMaterials[0] = eyes;
            newMaterials[1] = red;
            imRed = true;
            imBlue = false;
            model.GetComponent<SkinnedMeshRenderer>().materials = newMaterials;
            gameObject.layer = LayerMask.NameToLayer("Rojo");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(deadTag))
        {
            Die();
        }
    }

}
