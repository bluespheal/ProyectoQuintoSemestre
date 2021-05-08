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
            deadTag = "bateRojo";
            newMaterials[0] = eyes;
            newMaterials[1] = blue;
            imRed = false;
            imBlue = true;
            gameObject.layer = LayerMask.NameToLayer("Color1");
            model.GetComponent<SkinnedMeshRenderer>().materials = newMaterials;
        }
        else
        {
            deadTag = "bateAzul";
            newMaterials[0] = eyes;
            newMaterials[1] = red;
            imRed = true;
            imBlue = false;
            gameObject.layer = LayerMask.NameToLayer("Color2");
            model.GetComponent<SkinnedMeshRenderer>().materials = newMaterials;
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