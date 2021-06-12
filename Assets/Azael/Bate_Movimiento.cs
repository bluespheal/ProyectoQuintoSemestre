using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bate_Movimiento : MonoBehaviour
{
    GameObject player;
    public GameObject playerCamara;
    Vector3 playerPos;
    bool choque = false;
    public float distanciaMaxima;
    float distancia;
    Vector3 posInicial;
    Vector3 posActual;
    public float velRegreso;

    private void Start()
    {
        //Debug.Log(transform.position);
        //Obtener referencia al jugador
        player = GameObject.FindGameObjectWithTag("PlayerFoot");
        playerCamara = GameObject.FindGameObjectWithTag("Player");
        posInicial = transform.position;
        transform.rotation = playerCamara.transform.rotation;
    }

    void LateUpdate()
    {
        //Obtener posicion del jugador en todo momento
        playerPos = playerCamara.transform.position;
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
        else if(other.gameObject.CompareTag("Escudo") || other.gameObject.CompareTag("Boss"))
        {
            choque = true;
        }
    }

    private void OnDisable()
    {
        print("Se desactivo");
    }


    private void OnDestroy()
    {
        PlayerControllerVR pc = player.GetComponent<PlayerControllerVR>();
        if (this.gameObject.name == "Bate_Rojo(Clone)")
        {
            pc.lanzadoRojo = false;
            pc.bateRojo_prefab.SetActive(true);
        }
        if (this.gameObject.name == "Bate_Azul(Clone)")
        {
            pc.lanzadoAzul = false;
            pc.bateAzul_prefab.SetActive(true);
        }
        choque = false;
    }
}
