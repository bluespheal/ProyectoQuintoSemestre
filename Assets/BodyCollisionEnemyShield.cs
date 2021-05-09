using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollisionEnemyShield : MonoBehaviour
{
    public EnemyShield me;
    public Cuerpo parte;
    // Start is called before the first frame update
    void Start()
    {
        me = GetComponentInParent<EnemyShield>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(me.deadTag) && !me.hasShield)
        {
            me.CollisionDetected(this);
        }
    }
}
