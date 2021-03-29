using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CondicionAtaque", menuName = "Enemys_AI/Condiciones/CondicionAtaque")]
public class CondicionAtaque : Condiciones
{
    public override bool Test(MeleeMachine agente)
    {
        //Debug.Log(agente.target);
        return (agente.target && agente.meleeRange);
    }
}
