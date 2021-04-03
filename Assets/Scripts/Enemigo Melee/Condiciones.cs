using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Condiciones : ScriptableObject
{
    public virtual bool Test(MeleeMachine agente)
    {
        return false;
    }
}
