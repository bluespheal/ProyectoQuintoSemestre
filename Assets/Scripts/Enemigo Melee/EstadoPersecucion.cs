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
            agente.anim.SetBool("run", false);
        }
    }

    public override void Update()
    {
        //Cuando detectemos un objetivo, el enemigo lo comienza a perseguir
        if (agente.target == null)
        {
            return;
        }
        nav.SetDestination(agente.target.transform.position);
        //var dircetion = agente.target.transform.position - gameObject.transform.position;
        //dircetion.Normalize();

        //dircetion.y = 0.0f;
        //Transformamos la posicion global en local para perseguir de forma correcta
        //movementController.Move(gameObject.transform.InverseTransformDirection(dircetion));
        //Recrear gravedad

    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log(hit.collider);

    }
}
