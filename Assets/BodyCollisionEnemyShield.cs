using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollisionEnemyShield : MonoBehaviour
{
    public EnemyShield me;
    public Cuerpo parte;
    public bool active;
    Collider coll;
    bool yasta;

    void Start()
    {
        me = GetComponentInParent<EnemyShield>();
        active = true;
        coll = GetComponent<Collider>();
        //print(coll);
        coll.isTrigger = active;
    }

    private void Update()
    {
        if(!me.hasShield && !yasta)
        {
            StartCoroutine(activarColl());
        }
    }

    IEnumerator activarColl()
    {
        yasta = true;
        yield return new WaitForSeconds(0.5f);
        active = false;
        coll.isTrigger = active;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(me.deadTag) && !me.hasShield)
        {
            me.CollisionDetected(this);
        }
    }
}
