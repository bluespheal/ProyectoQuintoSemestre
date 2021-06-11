using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShieldTraining : EnemyTraining
{
    public int maxShieldHealth = 1;
    public int currentShieldHealth;
    public GameObject shield;
    public GameObject shieldR;
    public GameObject shieldB;
    public EscudoTraining actualShield;
    public bool hasShield;

    
    private void OnEnable()
    {
        
    }
    private void Start()
    {
        currentHealth = maxHealth;
        currentShieldHealth = maxShieldHealth;
        newMaterials = new Material[2];
        DefineColor();
        DefineShieldColor();
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
