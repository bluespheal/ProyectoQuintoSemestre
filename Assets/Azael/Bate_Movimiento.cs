using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bate_Movimiento : MonoBehaviour
{
    GameObject player;
    Vector3 playerPos;
    bool choque = false;
    public float distanciaMaxima;
    float distancia;
    Vector3 posInicial;
    Vector3 posActual;
    public float velRegreso;

    private void Start()
    {
        //Obtener referencia al jugador
        player = GameObject.FindGameObjectWithTag("Player");
        posInicial = transform.position;
        transform.rotation = player.transform.rotation;
    }

    void Update()
    {
        //Obtener posicion del jugador en todo momento
        playerPos = player.transform.position;
        //Obtener posicion actual del bate
        posActual = transform.position;
        //Calcular la distancia que ha avanzado
        distancia = Vector3.Distance(posInicial, posActual);

        if(distancia >= distanciaMaxima)
        {
            choque = true;
        }

        //Regresar al chocar o alcanzar la distancia maxima
        if(choque)
        {
            Regresar();
        }
    }

    //Rotar sobre si mismo, pero aun no se como hacerlo bien
    void Rotar()
    {
        transform.Rotate(Vector3.right * Time.deltaTime, 10.0f, Space.Self);
    }

    //Regresar a la posicion del jugador
    void Regresar()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos, velRegreso);
    }

    private void OnCollisionEnter(Collision collision)
    {
        choque = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destruir el objeto al entrar al trigger del jugador
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        choque = false;
    }
}
