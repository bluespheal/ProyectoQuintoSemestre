using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoIdle : Estado
{
    int idleInt;
    //Aun en desarrollo
    public override void OnEnable()
    {
        base.OnEnable();
        //Debug.Log("Entro a idle");
        //agente.anim.SetBool("idle", true);
        //Detenemos el movimento de la IA
        //movementController.Move(Vector3.zero);
        //Nos aseguramos de que perdio el target
        agente.target = null;
        agente.anim.SetBool("idle", true);
    }
    public override void OnDisable()
    {
        base.OnDisable();
        agente.anim.SetBool("idle", false);
    }

    public void IdleSelect()
    {
        idleInt = Random.Range(1, 10);
        if (idleInt == 2)
            agente.anim.SetTrigger("Idle2");
        else if(idleInt == 4)
            agente.anim.SetTrigger("Idle3");
        else
            return;
    }
}
