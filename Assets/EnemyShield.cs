using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : Enemy1
{
    public int maxShieldHealth = 1;
    public int currentHealth;
    public int currentShieldHealth;
    public GameObject shield;
    public GameObject shieldR;
    public GameObject shieldB;
    public Escudo actualShield;
    public bool hasShield;

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
    public void CollisionDetected(BodyCollisionEnemyShield collision)
    {
        TakeDamage(1);
    }
}