using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoIdle : Estado
{
    public override void OnEnable()
    {
        base.OnEnable();
        //Detenemos el movimento de la IA
        movementController.Move(Vector3.zero);
        //Nos aseguramos de que perdio el target
        agente.target = null;
    }
}
