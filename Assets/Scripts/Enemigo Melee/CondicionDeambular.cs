using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CondicionDeambular", menuName = "Enemys_AI/Condiciones/CondicionDeambular")]
public class CondicionDeambular : Condiciones
{
    public float tiempoEspera = 2.0f, tiempoTranscurrido = 0;

    public override bool Test(MeleeMachine agente)
    {
        tiempoTranscurrido += Time.deltaTime;
        if (tiempoTranscurrido >= tiempoEspera)
        {
            tiempoTranscurrido = 0;
            return true;
        }
        return false;
    }
}
