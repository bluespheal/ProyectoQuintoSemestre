using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnerTorretasTestZone : MonoBehaviour
{
    public GameObject[] torretas = new GameObject[4];

    private void OnCollisionEnter(Collision collision)
    {
        //Activar las torretas nuevamente al golpear el boton
        if(collision.gameObject.CompareTag("bateRojo") || collision.gameObject.CompareTag("bateAzul"))
        {
            LeanTween.pauseAll();
            for(int i = 0; i < 4; i++)
            {
                //Revisar si estan desactivadas y activarlas si es el caso
                if(!torretas[i].activeSelf)
                {
                    torretas[i].SetActive(true);
                }
            }
        }
    }
}
