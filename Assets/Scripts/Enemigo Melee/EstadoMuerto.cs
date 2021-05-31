using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoMuerto : Estado
{
    public override void OnEnable()
    {
        base.OnEnable();
        //Empesamos a ejecutar la animacion de correr
        agente.anim.SetTrigger("die");
        nav.SetDestination(agente.transform.position);
    }
}
