using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespanerTestZone : MonoBehaviour
{

    public GameObject Enemigo;
    public GameObject ne;
    public Transform SpawnPos;
    public bool creado;
    private void OnCollisionEnter(Collision collision)
    {
        //Activar las torretas nuevamente al golpear el boton
        if (collision.gameObject.CompareTag("bateRojo") || collision.gameObject.CompareTag("bateAzul"))
        {
            //Revisar si estan desactivadas y activarlas si es el caso
            if (!creado)
            {
                creado = true;
                ne = Instantiate(Enemigo, SpawnPos.position, SpawnPos.rotation);
                ne.GetComponent<DisolveTraining>().spawner = this;
            }
        }

    }
}
