//Movimiento y ataque de la torreta

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    [Header("Tipo de disparo")]
    public bool dispararRojo;
    public bool dispararAzul;
    public bool dispararAmbos = true;
    public float cadencia = 1.0f;
    float cadenciaInicial;

    [Header("Transforms")]
    public GameObject posicionBala;
    public GameObject posicionRayo;
    Transform posInicial;

    [Header("Prefabs")]
    public GameObject prefab_bala_azul;
    public GameObject prefab_bala_rojo;

    [Header("Layer a disparar")]
    public LayerMask detection;

    private void Start()
    {
        posInicial = gameObject.transform;
        cadenciaInicial = cadencia;
        Idle();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Morir
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Pausar LeenTween para que gire si vuelve a detectar al jugador
            LeanTween.pauseAll();
            cadencia = cadenciaInicial; //Reiniciar cadencia
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Regresar();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Rotar siguiendo la posicion del jugador
            Vector3 objetivo = other.transform.position - transform.position;
            objetivo.y = 0.0f;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(objetivo), Time.time * 1.0f);
            posicionRayo.transform.rotation = Quaternion.RotateTowards(posicionRayo.transform.rotation, Quaternion.LookRotation(objetivo), Time.time * 1.0f);
            Detection();
        }
    }

    //Idle de la torreta, gira 90 grados a la derecha 
    void Idle()
    {
        LeanTween.rotate(gameObject, new Vector3(0.0f, 90.0f, 0.0f), 2.0f).setOnComplete(Idle2);
        LeanTween.rotate(posicionRayo.gameObject, new Vector3(0.0f, 90.0f, 0.0f), 2.0f);
    }

    //Y luego a la izquierda
    void Idle2()
    {
        LeanTween.rotate(gameObject, new Vector3(0.0f, -89.0f, 0.0f), 2.0f).setOnComplete(Idle);
        LeanTween.rotate(posicionRayo.gameObject, new Vector3(0.0f, -89.0f, 0.0f), 2.0f);
    }

    //Volver a su posicion inicial y luego a idle
    private void Regresar()
    {
        LeanTween.rotate(gameObject, posInicial.position, 1.0f).setOnComplete(Idle);
        LeanTween.rotate(posicionRayo.gameObject, posInicial.position, 1.0f);
    }


    //Detectar si el rayo toca al jugador
    private void Detection()
    {
        RaycastHit hit;

        Ray direction = new Ray(posicionRayo.transform.position, posicionRayo.transform.forward);

        if (Physics.Raycast(direction, out hit, 20f, detection))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                cadencia -= Time.deltaTime;
                if (cadencia <= 0.0f)
                {
                    Shoot();
                    cadencia = 1.5f;
                }
            }
            else
            {
                cadencia = 1.5f;
            }
        }
    }

    //Disparar, obviamente
    public void Shoot()
    {
        GameObject bala;

        //Disparar segun el tipo de bala elegido
        if (dispararAmbos)
        {
            int randNum = Random.Range(0, 20);

            if (randNum < 10)
            {
                bala = prefab_bala_azul;
            }
            else
            {
                bala = prefab_bala_rojo;
            }

            Instantiate(bala, posicionBala.transform.position, posicionBala.transform.rotation);
        }
        else if(dispararAzul)
        {
            bala = prefab_bala_azul;
            Instantiate(bala, posicionBala.transform.position, posicionBala.transform.rotation);
        }
        else if(dispararRojo)
        {
            bala = prefab_bala_rojo;
            Instantiate(bala, posicionBala.transform.position, posicionBala.transform.rotation);
        }
    }

    private void OnGUI()
    {
        Debug.DrawRay(posicionRayo.transform.position, posicionRayo.transform.forward * 15, Color.red);
    }
}
