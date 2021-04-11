using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "CondicionPerder", menuName = "Enemys_AI/Condiciones/CondicionPerder")]
public class CondicionPerder : Condiciones
{
    public override bool Test(MeleeMachine agente)
    {
        //Revisamos que el agente ya no pueda ver al jugador y no este atacando
        return (agente.target == null && !agente.attacking);
    }
}
