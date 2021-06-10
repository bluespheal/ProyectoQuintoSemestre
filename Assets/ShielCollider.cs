using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShielCollider : MonoBehaviour
{
    public AgentShield me;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bateAzul") || collision.gameObject.CompareTag("balaReflejada") || collision.gameObject.CompareTag("bateRojo"))
        {
            me.CollisionDetectedShield(this);
        }
    }
}
