using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float vel; //Velocidad
    public bool reflected = false;

    void Start()
    {
        //Invoke("Destructor", 10);//Destruir el objeto si no choca
        Destroy(gameObject, 10.0f);
        transform.parent = null;
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
        transform.rotation = direccion.rotation; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Destriur al chocar con el jugador
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Barrera"))
        {
            Destroy(gameObject);
        }
    }
}
