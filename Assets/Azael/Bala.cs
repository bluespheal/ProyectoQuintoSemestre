using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float vel; //Velocidad
    public bool reflected = false;
    public ParticleSystem particles;
    

    void Start()
    {
        //Invoke("Destructor", 10);//Destruir el objeto si no choca
        Destroy(gameObject, 10.0f);
        transform.parent = null;

        particles = this.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (!reflected)
        {
            transform.Translate(Vector3.forward * vel * Time.deltaTime);//Mover hacia adelante
            //transform.Translate(Vector3.down * Time.deltaTime * (vel / 15));//Mover hacia abajo
        }
        else
        {
            //transform.Translate(Vector3.back * (vel * 3) * Time.deltaTime);//Mover hacia atrás si es reflejado
            transform.Translate(Vector3.forward * (vel * 3) * Time.deltaTime);
        }

    }

    public void Reflejar(Transform direccion)
    {
        this.tag = "balaReflejada";
        transform.rotation = direccion.rotation; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        particles.Play();
        //Destriur al chocar con el jugador
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Barrera") || collision.gameObject.CompareTag("Caja"))
        {
            Destroy(gameObject);
        }
    }
}
