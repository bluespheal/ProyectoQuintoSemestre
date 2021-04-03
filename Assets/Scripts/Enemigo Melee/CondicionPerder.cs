using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "CondicionPerder", menuName = "Enemys_AI/Condiciones/CondicionPerder")]
public class CondicionPerder : Condiciones
{
    public override bool Test(MeleeMachine agente)
    {
        return agente.target == null;
    }
}
