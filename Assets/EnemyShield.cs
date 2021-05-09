using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    public int maxHealth = 1;
    public int maxShieldHealth = 1;
    public int currentHealth;
    public int currentShieldHealth;
    public bool imRed;
    public bool imBlue;
    public int color;
    public Material red;
    public Material blue;
    public GameObject model;
    public GameObject shield;
    public GameObject shieldR;
    public GameObject shieldB;
    public Escudo actualShield;
    public bool hasShield;

    public Material eyes;
    public Material[] newMaterials;
    string deadTag;
    public DisolbingController ControlParticulas;

    void Start()
    {
        newMaterials = new Material[2];
        currentHealth = maxHealth;
        currentShieldHealth = maxShieldHealth;
        DefineColor();
        DefineShieldColor();
    }

    void Die()
    {
        if (currentShieldHealth < 1)
        {
            this.ControlParticulas.LamarDisolve();
        }
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
        Debug.Log("Entre a Color");
        color = Random.Range(0, 2);
        //print(color);
        if (color == 0)
        {
            deadTag = "bateAzul";
            newMaterials[0] = eyes;
            newMaterials[1] = blue;
            imRed = false;
            imBlue = true;
            gameObject.layer = LayerMask.NameToLayer("Azul");
            model.GetComponent<SkinnedMeshRenderer>().material = blue;
        }
        else
        {
            deadTag = "bateRojo";
            newMaterials[0] = eyes;
            newMaterials[1] = red;
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
            actualShield.actualShield = shieldB;
        }
        else
        {
            shield.gameObject.layer = LayerMask.NameToLayer("Rojo");
            shieldB.SetActive(false);
            shieldR.SetActive(true);
            actualShield.actualShield = shieldR;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("a");
        if (collision.gameObject.CompareTag(deadTag) && !hasShield)
        {
            TakeDamage(1);
        }
    }
}