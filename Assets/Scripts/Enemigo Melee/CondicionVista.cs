using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CondicionVista", menuName = "Enemys_AI/Condiciones/CondicionVista")]
public class CondicionVista : Condiciones
{
    public override bool Test(MeleeMachine agente)
    {
        //Debug.Log(agente.target);
        //Rebisamos que nuestro agente pueda ver al jugador, no este en rango de ataque y no este atacando
        return (agente.target && !agente.meleeRange && !agente.attacking);
    }
}
