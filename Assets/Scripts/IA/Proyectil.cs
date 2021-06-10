using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public TorretaIA torretin;
    public Material blueG;
    public Material RedG;

    private void OnEnable()
    {
        int color = Random.Range(0, 2);
        string layer;
        if (color == 1)
        {
            gameObject.layer = LayerMask.NameToLayer("Azul");
            gameObject.GetComponent<MeshRenderer>().material = blueG;
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Rojo");
            gameObject.GetComponent<MeshRenderer>().material = RedG;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("muro") || collision.gameObject.CompareTag("Caja"))
        {
            torretin.Fallar();
        }else if (collision.gameObject.CompareTag("Player"))
        {
            torretin.Acertar();

        }
    }
}
