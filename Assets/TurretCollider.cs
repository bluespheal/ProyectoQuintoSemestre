using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCollider : MonoBehaviour
{
    public AgentShield me;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bate") || collision.gameObject.CompareTag("BalaReflejada"))
        {
            me.CollisionDetected(this);
        }
    }
}
