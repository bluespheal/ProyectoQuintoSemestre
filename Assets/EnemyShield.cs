using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : Enemy1
{
    public int maxShieldHealth = 1;
    public int currentShieldHealth;
    public GameObject shield;
    public GameObject shieldR;
    public GameObject shieldB;
    public EscudoTraining actualShield;
    public bool hasShield;

    void Start()
    {
        GameManager.Instance.ContarEnemigo(this.gameObject);
        newMaterials = new Material[2];
        currentHealth = maxHealth;
        currentShieldHealth = maxShieldHealth;
        DefineColor();
        DefineShieldColor();
        hasShield = true;
    }

    protected override void Die()
    {
        if (currentShieldHealth < 1)
        {
            arma.transform.gameObject.tag = "Untagged";
            arma.transform.parent = null;
            arma.GetComponent<Rigidbody>().isKinematic = false;
            GameManager.Instance.DescontarEnemigo(this.gameObject);
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
        SoundManager.playSound(SoundManager.Sound.hit);
        TakeDamage(1);
    }
}