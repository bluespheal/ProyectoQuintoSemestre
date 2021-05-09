using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Cuerpo
{
    CABEZA, CUELLO, PECHO, TORZO, BRAZO_I, ANTEBRAZO_I, MANO_I, BRAZO_D, ANTEBRAZO_D, MANO_D, MUSLO_I, PIERNA_I, PIE_I, MUSLO_D, PIERNA_D, PIE_D
}

public class BodyCollisionEnemyMelee : MonoBehaviour
{
    public Enemy1 me;
    public Cuerpo parte;
    // Start is called before the first frame update
    void Start()
    {
        me = GetComponentInParent<Enemy1>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.CompareTag(me.deadTag));
        if (collision.gameObject.CompareTag(me.deadTag))
        {
            me.CollisionDetected(this);
        }
    }
}
