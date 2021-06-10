using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public TorretaIA torretin;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("muro") || collision.gameObject.CompareTag("Caja"))
        {
            torretin.Fallar();
            this.gameObject.SetActive(false);
        }else if (collision.gameObject.CompareTag("PlayerFoot"))
        {
            torretin.Acertar();
            this.gameObject.SetActive(false);

        }
    }
}
