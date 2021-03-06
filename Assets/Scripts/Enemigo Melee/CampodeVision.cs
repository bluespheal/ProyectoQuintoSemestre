using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampodeVision : MonoBehaviour
{
    public string tagObjetivo = "Player";
    public MeleeMachine infoMelee;
    Vector3 posicionActual;
    Vector3 posicionObjetico;
    Vector3 direccion;
    Ray ray;
    
    private void Awake()
    {
        if(!infoMelee)
            infoMelee = GetComponentInParent<MeleeMachine>();
    }

    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other);
        //Analiza el objeto con el que colisiona
        if(other.gameObject.CompareTag("Player"))
        {
                //Si es el jugador guarda  su posicion
            posicionActual = gameObject.transform.position;
            posicionObjetico = other.transform.position;
            direccion = posicionObjetico - posicionActual;
            //Dispara un Raycast para saber si no hay algo que lo oculte
            ray = new Ray(posicionActual, direccion.normalized);
            RaycastHit hit;
            Debug.DrawRay(posicionActual, direccion);
            if(Physics.Raycast(ray, out hit, direccion.magnitude))
            {
                //Si tiene una vista directa lo vuelve su objetivo
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    infoMelee.target = other.gameObject;
                    return;
                }
            }
        }
        //Eliminamos el tarjet para evitar errores
        //infoMelee.target = null;
    }

    private void OnTriggerExit(Collider other)
    {
        //Si el jugador sale de nuestro campo de vision...
        if(infoMelee.target!=null && other.gameObject.CompareTag("Player"))
        {
            //... perdemos el "taeget" del jugador
            infoMelee.target = null;
        }
    }
}
