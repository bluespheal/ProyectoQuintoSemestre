using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPersecucion : Estado
{
    //Un GO para saber si esta activo
    public GameObject indicator;
    //Encender el indicador de persecusion
    public override void OnEnable()
    {
        base.OnEnable();
        //Empesamos a ejecutar la animacion de correr
        agente.anim.SetBool("run",true);
        Debug.Log("Entro a run");
        if (indicator)
        {
            indicator.SetActive(true);
        }
    }
    //Apagar el indicador de persecusion y la animacion
    public override void OnDisable()
    {
        base.OnDisable();
        if (indicator)
        {
            indicator.SetActive(false);
        }
        //Desactivamos la animacion de correr
        agente.anim.SetBool("run", false);
    }

    public override void Update()
    {
        //Cuando perdemos el objetivo, no ejecutamos el resto del update
        if (agente.target == null)
        {
            return;
        }
        //Le decimos al pathfinding que mueva al enemigo hacia el jugador
        nav.SetDestination(agente.target.transform.position);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log(hit.collider);
        Debug.Log(Vector3.Distance(agente.target.transform.position, gameObject.transform.position));
    }
}
