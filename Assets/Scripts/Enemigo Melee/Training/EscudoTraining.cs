using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoTraining : MonoBehaviour
{
    public EnemyShieldTraining Enemy;
    public GameObject actualShield;

    void Start()
    {
        Enemy = GetComponentInParent<EnemyShieldTraining>();
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
