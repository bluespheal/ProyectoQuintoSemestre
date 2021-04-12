using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoAtaque : Estado
{
    public override void OnEnable()
    {
        base.OnEnable();
        //Entramos en estado de ataque y ordenamos que ejecute 1 animacion de ataque
        agente.anim.SetBool("attack",true);
        agente.attacking = true;
        agente.anim.SetTrigger("hit");
    }
    public override void OnDisable()
    {
        base.OnDisable();
        //Salimos del estado de ataque
        agente.anim.SetBool("attack", false);
        
    }

    public override void Update()
    {
       
    }
    //Lo llama la animacion del ataque por medio de un evento
    //ejecuta 1 animacion de ataque si el estado de actaque esta activo
    public void hitReady()
    {
        if(agente.meleeRange)
            agente.anim.SetTrigger("attack");
        else
            agente.attacking = false;

        Debug.Log("Doro, monsta cado");
    }
}
