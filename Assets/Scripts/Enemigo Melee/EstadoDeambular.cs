using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EstadoDeambular : Estado
{
    public float angleModifier = 1;
    public bool deambulando = false;
    public float velMovDeambular = 0.5f;
    public float velRotacion = 0.01f;
    private float velMovimiento = 0;
    //El "?" es para que se pueda asignar null como valor al V3
    Vector3? direccion = null;

    public override void Update()
    {
        base.Update();
        if (deambulando)
        {
            //Si ya hay una direccion para deambular...
            if (direccion.HasValue)
            {
                //...La IA se direge ahi
                //movementController.Move(direccion.Value.normalized * velMovimiento);
            }
            return;
        }
        //Si no estamos deambulando, entramos en el estado
        deambulando = true;
        StartCoroutine(Deambula());
    }

    IEnumerator Deambula()
    {
        Vector3 dirRotacion = RotarAgente();
        direccion = dirRotacion;
        velMovimiento = velMovDeambular;
        yield return new WaitForSeconds(2);
        StartCoroutine(Buscar());
    }

    private Vector3 RotarAgente()
    {
        float orientacionDeambular = Random.Range(-30f, 30f) * angleModifier;
        var nuevaRotacion = Quaternion.AngleAxis(orientacionDeambular, Vector3.up);
        var dirRotacion = nuevaRotacion * Vector3.forward;
        //movementController.Rotate(dirRotacion);
        return dirRotacion;
    }

    IEnumerator Buscar()
    {
        direccion = null;
        //movementController.Move(Vector3.zero);
        Vector3 dirRotacion = RotarAgente();
        velMovimiento = velRotacion;
        direccion = dirRotacion;
        yield return new WaitForSeconds(3);
        deambulando = false;
    }
}
