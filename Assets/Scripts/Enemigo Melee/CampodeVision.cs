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
        infoMelee = GetComponentInParent<MeleeMachine>();
    }

    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        GameObject objetivo = other.gameObject;
        string tag = objetivo.tag;
        if(tag.Equals(tagObjetivo) == false)
        {
            return;
        }
        posicionActual = gameObject.transform.position;
        posicionObjetico = objetivo.transform.position;
        direccion = posicionObjetico - posicionActual;

        ray = new Ray(posicionActual, direccion.normalized);
        RaycastHit hit;
        Debug.DrawRay(posicionActual, direccion);
        if(Physics.Raycast(ray, out hit, direccion.magnitude))
        {
            if (hit.collider.gameObject.tag.Equals(tagObjetivo))
            {
                infoMelee.target = objetivo;
                return;
            }
        }
        infoMelee.target = null;
    }

    private void OnTriggerExit(Collider other)
    {
        //Si el jugador sale de nuestro campo de vision...
        if(infoMelee.target!=null && other.gameObject == infoMelee.target)
        {
            //... ya no segimos al jugador
            infoMelee.target = null;
        }
    }
}
