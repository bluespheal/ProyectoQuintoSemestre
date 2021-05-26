using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public bool imRed;
    public bool imBlue;
    public int color;
    public Material rojo;
    public Material azul;
    public float TiempoMovimiento;

    void Start()
    {
        DefineColor();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("bateRojo") || collision.gameObject.CompareTag("bateAzul"))
        {
            //Desactivar el escudo del jefe

            //Bajar generador
            BajarGenerador();
        }
    }

    public void BajarGenerador()
    {
        LeanTween.moveY(gameObject, -1.2f, TiempoMovimiento);
    }

    public void SubirGenerador()
    {
        DefineColor();
        LeanTween.moveY(gameObject, 1.0f, TiempoMovimiento);
    }

    public void DefineColor()
    {
        color = Random.Range(0, 2);

        if (color == 0)
        {
            imRed = false;
            imBlue = true;
            gameObject.layer = LayerMask.NameToLayer("Azul");
            gameObject.GetComponent<MeshRenderer>().material = azul;

        }
        else
        {
            imRed = true;
            imBlue = false;
            gameObject.layer = LayerMask.NameToLayer("Rojo");
            gameObject.GetComponent<MeshRenderer>().material = rojo;
        }
    }
}
