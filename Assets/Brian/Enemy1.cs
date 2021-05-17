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
    public GameObject arma;
    public string deadTag;
    public DisolbingController ControlParticulas;

    void Start()
    {
        GameManager.Instance.ContarEnemigo(this.gameObject);
        newMaterials = new Material[2];
        currentHealth = maxHealth;
        DefineColor();
    }
    void Die()
    {
        arma.transform.gameObject.tag = "Untagged";
        arma.transform.parent = null;
        arma.GetComponent<Rigidbody>().isKinematic = false;
        GameManager.Instance.DescontarEnemigo(this.gameObject);
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

    public void CollisionDetected(BodyCollisionEnemyMelee collision)
    {
        TakeDamage(1);
    }
}
