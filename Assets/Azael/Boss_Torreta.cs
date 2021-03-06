using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Torreta : MonoBehaviour
{
    [Header("Tipo de disparo")]
    public bool dispararRojo;
    public bool dispararAzul;
    public bool dispararAmbos = true;
    public float cadencia;
    float cadenciaInicial;

    [Header("Transforms")]
    public GameObject posicionBala;
    public GameObject posicionRayo;
    //Transform posInicial;

    [Header("Prefabs")]
    public GameObject prefab_bala_azul;
    public GameObject prefab_bala_rojo;

    [Header("Layer a disparar")]
    public LayerMask detection;

    public GameObject canon, canon_guard, barrera;

    GameObject player;

    private void Start()
    {
        //posInicial = plataforma_base.transform;
        cadenciaInicial = cadencia;
        player = GameObject.FindGameObjectWithTag("Player");
        //GameManager.Instance.ContarEnemigo(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Morir
        if (collision.gameObject.CompareTag("Bate") || collision.gameObject.CompareTag("Danger"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        //GameManager.Instance.DescontarEnemigo(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cadencia = cadenciaInicial; //Reiniciar cadencia
        }
        if (other.gameObject.CompareTag("Danger"))
        {
            SubirBarrera();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        /*if (other.gameObject.CompareTag("Player"))
        {
            Regresar();
        }
        if (other.gameObject.CompareTag("Danger"))
        {
            BajarBarrera();
        }*/
    }

    private void Update()
    {
        Vector3 objetivo = player.transform.position - transform.position;
        //Hacia donde rotar la base
        Vector3 objetivo2 = player.transform.position - transform.position;
        objetivo2.y = 0.0f;
        canon.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(objetivo), Time.time * 50.0f);
        canon_guard.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(objetivo2), Time.time * 50.0f);
        posicionRayo.transform.rotation = Quaternion.RotateTowards(posicionRayo.transform.rotation, Quaternion.LookRotation(objetivo), Time.time * 1.0f);
        Detection();
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Rotar siguiendo la posicion del jugador
            Vector3 objetivo = other.transform.position - transform.position;
            //Hacia donde rotar la base
            Vector3 objetivo2 = other.transform.position - transform.position;
            objetivo2.y = 0.0f;
            canon.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(objetivo), Time.time * 50.0f);
            canon_guard.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(objetivo2), Time.time * 50.0f);
            posicionRayo.transform.rotation = Quaternion.RotateTowards(posicionRayo.transform.rotation, Quaternion.LookRotation(objetivo), Time.time * 1.0f);
            Detection();
        }
    }*/

    //Idle de la torreta, gira 90 grados a la derecha 
    /*void Idle()
    {
        LeanTween.rotateLocal(plataforma_base, new Vector3(0.0f, 90.0f, 0.0f), 2.0f).setOnComplete(Idle2);
        LeanTween.rotateLocal(posicionRayo.gameObject, new Vector3(0.0f, 90.0f, 0.0f), 2.0f);
    }

    //Y luego a la izquierda
    void Idle2()
    {
        LeanTween.rotateLocal(plataforma_base, new Vector3(0.0f, -89.0f, 0.0f), 2.0f).setOnComplete(Idle);
        LeanTween.rotateLocal(posicionRayo.gameObject, new Vector3(0.0f, -89.0f, 0.0f), 2.0f);
    }*/

    //Volver a su posicion inicial y luego a idle
    /*private void Regresar()
    {
        LeanTween.rotate(plataforma_base, posInicial.position, 1.0f).setOnComplete(Idle);
        LeanTween.rotate(canon, posInicial.position, 1.0f);
        LeanTween.rotate(posicionRayo.gameObject, posInicial.position, 1.0f);
    }*/


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
                    cadencia = cadenciaInicial;
                }
            }
            else
            {
                cadencia = cadenciaInicial;
            }
        }
    }

    //Defenderse
    public void SubirBarrera()
    {
        LeanTween.moveLocalY(barrera, 1.0f, 1.0f).setOnComplete(BajarBarrera);
    }

    public void BajarBarrera()
    {
        LeanTween.moveLocalY(barrera, -1.4f, 1.0f);
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
        else if (dispararAzul)
        {
            bala = prefab_bala_azul;
            Instantiate(bala, posicionBala.transform.position, posicionBala.transform.rotation);
        }
        else if (dispararRojo)
        {
            bala = prefab_bala_rojo;
            Instantiate(bala, posicionBala.transform.position, posicionBala.transform.rotation);
        }
    }

    private void OnGUI()
    {
        Debug.DrawRay(posicionRayo.transform.position, posicionRayo.transform.forward * 20, Color.red);
    }
}
