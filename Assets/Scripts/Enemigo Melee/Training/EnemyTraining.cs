using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTraining : MonoBehaviour
{
    public int maxHealth = 1;
    protected int currentHealth;
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
    public DisolveTraining ControlParticulas;

    void Start()
    {
        Debug.Log("aber");
        newMaterials = new Material[2];
        currentHealth = maxHealth;
        DefineColor();
    }
    protected virtual void Die()
    {
        //GameManager.Instance.DescontarEnemigo(this.gameObject);
        this.ControlParticulas.LamarDisolve();
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
        Debug.Log(newMaterials[0]);
        Debug.Log(newMaterials[1]);
        //color = Random.Range(0, 2);
        //print(color);
        if (color == 0)
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
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag(deadTag))
            TakeDamage(1);
    }
}
