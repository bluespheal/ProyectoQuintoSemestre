using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    public EnemyShield Enemy;
    public GameObject actualShield;

    void Start()
    {
        Enemy = GetComponentInParent<EnemyShield>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bateAzul"))
        {
            Enemy.currentShieldHealth--;
            Enemy.hasShield = false;
            gameObject.SetActive(Enemy.hasShield);
        }
        else if (other.CompareTag("bateRojo"))
        {
            Enemy.currentShieldHealth--;
            Enemy.hasShield = false;
            gameObject.SetActive(Enemy.hasShield);
        }
    }
}
