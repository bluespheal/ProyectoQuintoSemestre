using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CondicionVista", menuName = "Enemys_AI/Condiciones/CondicionVista")]
public class CondicionVista : Condiciones
{
    public override bool Test(MeleeMachine agente)
    {
        //Debug.Log(agente.target);
        return (agente.target && !agente.meleeRange );
    }
}
