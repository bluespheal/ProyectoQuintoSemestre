using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzar_Armas : MonoBehaviour
{
    public GameObject bateAzul_prefab;
    public GameObject bateRojo_prefab;
    public Transform lanzamientoPos;
    public float fuerza;
    public float distancia;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Lanzar(bateRojo_prefab);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Lanzar(bateAzul_prefab);
        }
    }

    public void Lanzar(GameObject _bate)
    {
        GameObject bate = Instantiate(_bate, lanzamientoPos.position, lanzamientoPos.rotation);
        Rigidbody rb = bate.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * fuerza, ForceMode.Impulse);
    }
}
