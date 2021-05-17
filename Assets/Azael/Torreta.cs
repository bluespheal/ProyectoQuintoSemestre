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
    public float cadencia;
    float cadenciaInicial;

    [Header("Transforms")]
    public GameObject posicionBala;
    public GameObject posicionRayo;
    Transform posInicial;

    [Header("Prefabs")]
    public GameObject prefab_bala_azul;
    public GameObject prefab_bala_rojo;

    [Header("Color Variant")]
    public bool imRed;
    public bool imBlue;
    public int color;
    public Material red;
    public Material blue;
    public GameObject modelBase;
    public GameObject modelBody;
    public GameObject modelHead;


    [Header("Layer a disparar")]
    public LayerMask detection;

    public GameObject basee, canon;
    public Animator anim;


    private void Start()
    {
        DefineColor();
        posInicial = basee.transform;
        cadenciaInicial = cadencia;
        Idle();
       GameManager.Instance.ContarEnemigo(gameObject);
        if (!GameManager.Instance.puerta)
            GameManager.Instance.puerta.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Morir
        if(collision.gameObject.CompareTag("Bate") || collision.gameObject.CompareTag("Danger"))
        {
            GameManager.Instance.DescontarEnemigo(this.gameObject);
            Destroy(gameObject);
        }
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
            objetivo.y = objetivo.y -1.0f;
            //Hacia donde rotar la base
            Vector3 objetivo2 = other.transform.position - transform.position;
            objetivo2.y = 0.0f;
            canon.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(objetivo), Time.time * 50.0f);
            basee.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(objetivo2), Time.time * 50.0f);
            posicionRayo.transform.rotation = Quaternion.RotateTowards(posicionRayo.transform.rotation, Quaternion.LookRotation(objetivo), Time.time);
            Detection();
        }
    }

    //Idle de la torreta, gira 90 grados a la derecha 
    void Idle()
    {
        LeanTween.rotateLocal(basee, new Vector3(0.0f, 90.0f , 0.0f), 2.0f).setOnComplete(Idle2);
        LeanTween.rotateLocal(posicionRayo.gameObject, new Vector3(0.0f, 90.0f, 0.0f), 2.0f);
    }

    //Y luego a la izquierda
    void Idle2()
    {
        LeanTween.rotateLocal(basee, new Vector3(0.0f, -89.0f, 0.0f), 2.0f).setOnComplete(Idle);
        LeanTween.rotateLocal(posicionRayo.gameObject, new Vector3(0.0f, -89.0f, 0.0f), 2.0f);
    }

    //Volver a su posicion inicial y luego a idle
    private void Regresar()
    {
        LeanTween.rotate(basee, posInicial.position, 1.0f).setOnComplete(Idle);
        LeanTween.rotate(canon, posInicial.position, 1.0f);
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
                    cadencia = cadenciaInicial;
                }
            }
            else
            {
                cadencia = cadenciaInicial;
            }
        }
    }

    //Disparar, obviamente
    public void Shoot()
    {
        //Iniciar animacion
        anim.SetTrigger("Disparar");

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
        Debug.DrawRay(posicionRayo.transform.position, posicionRayo.transform.forward * 20, Color.red);
    }

    public void DefineColor()
    {
        color = Random.Range(0, 2);
        if (color == 0)
        {
            imRed = false;
            imBlue = true;
            gameObject.layer = LayerMask.NameToLayer("Azul");
            modelBase.GetComponent<MeshRenderer>().material = blue;
            modelBody.GetComponent<MeshRenderer>().material = blue;
            modelHead.GetComponent<MeshRenderer>().material = blue;
        }
        else
        {
            imRed = true;
            imBlue = false;
            gameObject.layer = LayerMask.NameToLayer("Rojo");
            modelBase.GetComponent<MeshRenderer>().material = red;
            modelBody.GetComponent<MeshRenderer>().material = red;
            modelHead.GetComponent<MeshRenderer>().material = red;
        }
    }
}
