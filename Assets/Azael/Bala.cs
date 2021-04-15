using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float vel; //Velocidad

    void Start()
    {
        Invoke("Destructor", 10);//Destruir el objeto si no choca
        transform.parent = null;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * vel * Time.deltaTime); //Mover hacia adelante
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Destriur al chocar con el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void Destructor()
    {
        Destroy(gameObject);
    }
}
