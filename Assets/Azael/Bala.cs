using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float vel;
    public bool reflected = false;

    void Start()
    {
        Invoke("Destructor", 10);//Funcion para destruir el objeto si no choca
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
            transform.Translate(Vector3.back * (vel * 3) * Time.deltaTime);//Mover hacia atrás si es reflejado
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
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
