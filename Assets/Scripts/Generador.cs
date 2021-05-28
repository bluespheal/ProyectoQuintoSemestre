using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public bool imRed;
    public bool imBlue;
    public int color;
    public MeshRenderer areaColor;
    public MeshRenderer areaColor2;
    public Material rojo;
    public Material azul;
    public float TiempoMovimiento;
    public bool bajando;

    void Start()
    {
        this.bajando = false;
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
        this.bajando = true;
        LeanTween.moveY(gameObject, -4.5f, TiempoMovimiento).setOnComplete(Desactivar);
    }

    public void SubirGenerador()
    {
        this.bajando = false;
        DefineColor();
        LeanTween.moveY(gameObject, 0.0f, TiempoMovimiento);
    }

    void Desactivar()
    {
        this.bajando = false;
        this.gameObject.SetActive(false);
    }

    public void DefineColor()
    {
        color = Random.Range(0, 2);

        if (color == 0)
        {
            imRed = false;
            imBlue = true;
            this.gameObject.layer = LayerMask.NameToLayer("Azul");
            areaColor2.material = azul;
            areaColor.material = azul;

        }
        else
        {
            imRed = true;
            imBlue = false;
            this.gameObject.layer = LayerMask.NameToLayer("Rojo");
            areaColor2.material = rojo;
            areaColor.material = rojo;
        }
    }
}
