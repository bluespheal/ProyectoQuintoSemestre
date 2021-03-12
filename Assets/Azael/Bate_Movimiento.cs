using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bate_Movimiento : MonoBehaviour
{
    Vector3 puntoA;

    private void Start()
    {
        puntoA = gameObject.transform.position;
    }

    void Update()
    {
        Rotar();
    }

    void Rotar()
    {
        transform.Rotate(Vector3.right * Time.deltaTime, 10.0f);
    }

    void Regresar()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Regresar();
    }
}
