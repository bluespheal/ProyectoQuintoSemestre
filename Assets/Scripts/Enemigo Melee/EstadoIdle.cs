using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoIdle : Estado
{
    //Aun en desarrollo
    public override void OnEnable()
    {
        base.OnEnable();
        Debug.Log("Entro a idle");
        //agente.anim.SetBool("idle", true);
        //Detenemos el movimento de la IA
        //movementController.Move(Vector3.zero);
        //Nos aseguramos de que perdio el target
        agente.target = null;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        agente.anim.SetBool("idle", false);
    }
}
