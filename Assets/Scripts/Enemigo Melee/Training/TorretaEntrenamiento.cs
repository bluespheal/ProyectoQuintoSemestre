//Movimiento y ataque de la torreta para la escena de entrenamiento
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaEntrenamiento : MonoBehaviour
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

    public GameObject muro;


    private void OnEnable()
    {
        DefineColor();
        //Bajar su muro al activar la torreta
        LeanTween.moveY(muro, -1.7f, 1.0f);
        posInicial = basee.transform;
        cadenciaInicial = cadencia;
    }

    private void Start()
    {
        DefineColor();
        posInicial = basee.transform;
        cadenciaInicial = cadencia;
        //Bajar su muro al activar la torreta
        LeanTween.moveY(muro, -1.7f, 1.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Morir
        if (collision.gameObject.CompareTag("bateRojo") || collision.gameObject.CompareTag("Danger") || collision.gameObject.CompareTag("bateAzul"))
        {
            SoundManager.playSound(SoundManager.Sound.hit);
            this.gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cadencia = cadenciaInicial; //Reiniciar cadencia
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Rotar siguiendo la posicion del jugador
            Vector3 objetivo = other.transform.position - transform.position;
            objetivo.y = objetivo.y - 1.0f;
            //Hacia donde rotar la base
            Vector3 objetivo2 = other.transform.position - transform.position;
            objetivo2.y = 0.0f;
            canon.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(objetivo), Time.time * 50.0f);
            basee.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(objetivo2), Time.time * 50.0f);
            posicionRayo.transform.rotation = Quaternion.RotateTowards(posicionRayo.transform.rotation, Quaternion.LookRotation(objetivo), Time.time);
            Detection();
        }
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

    private void OnDisable()
    {
        //Subir su muro al desactivar la torreta
        LeanTween.moveY(muro, -0.3f, 1.0f);
    }
}
