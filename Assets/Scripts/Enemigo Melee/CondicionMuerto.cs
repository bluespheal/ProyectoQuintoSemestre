using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionMuerto : Condiciones
{
    public override bool Test(MeleeMachine agente)
    {
        //Debug.Log(agente.target);
        //Rebisamos que nuestro agente a muerto
        return (agente.muerto);
    }
}
