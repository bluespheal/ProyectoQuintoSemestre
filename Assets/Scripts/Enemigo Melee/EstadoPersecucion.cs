using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPersecucion : Estado
{
    //Un GO para saber si esta activo
    public GameObject indicator;
    //Encender el indicador
    public override void OnEnable()
    {
        base.OnEnable();
        if (indicator)
        {
            indicator.SetActive(true);
        }
    }
    //Apagar el indicador
    public override void OnDisable()
    {
        base.OnDisable();
        if (indicator)
        {
            indicator.SetActive(false);
        }
    }

    public override void Update()
    {
        //Cuando detectemos un objetivo, el enemigo lo comienza a perseguir
        if (agente.target == null)
        {
            return;
        }
        var dircetion = agente.target.transform.position - gameObject.transform.position;
        dircetion.Normalize();
        //Transformamos la posicion global en local para perseguir de forma correcta
        movementController.Move(gameObject.transform.InverseTransformDirection(dircetion));
    }
}
