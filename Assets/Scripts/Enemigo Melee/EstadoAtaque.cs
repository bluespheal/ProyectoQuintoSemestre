using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoAtaque : Estado
{
    public override void OnEnable()
    {
        base.OnEnable();
        agente.anim.SetBool("attack",true);
        agente.anim.SetTrigger("hit");
    }
    public override void OnDisable()
    {
        base.OnDisable();
        agente.anim.SetBool("attack", false);
        agente.attacking = false;
    }

    public override void Update()
    {
        //Cuando detectemos un objetivo, el enemigo lo comienza a perseguir
        if (!agente.attacking)
        {
            agente.attacking = true;
            agente.anim.SetTrigger("attack");
        }
        
    }

    public void hitReady()
    {
        agente.attacking = false;
        Debug.Log("Doro, monsta cado");
    }
}
