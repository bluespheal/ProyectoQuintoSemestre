using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lanzar_Armas : MonoBehaviour
{
    public GameObject bateAzul_prefab;
    public GameObject bateRojo_prefab;
    public Transform lanzamientoPos; //De donde saldra el arma
    public Image haircross;
    public float fuerza;

    void Update()
    {
        //Al presionar el boton se enciende la mira y al soltarlo de lanza el arma
        if(Input.GetKeyUp(KeyCode.Q))
        {
            haircross.enabled = false;
            Lanzar(bateRojo_prefab);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            haircross.enabled = false;
            Lanzar(bateAzul_prefab);
        }
        if(Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E))
        {
            haircross.enabled = true;
        }
    }

    //Lanzar bate
    public void Lanzar(GameObject _bate)
    {
        GameObject bate = Instantiate(_bate, lanzamientoPos.position, lanzamientoPos.rotation);
        Rigidbody rb = bate.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * fuerza, ForceMode.Impulse);
    }
}
