using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeGeneradores : MonoBehaviour
{
    public GameObject[] generadores = new GameObject[4];
    public float segundosCambio;
    float segundos;
    int generadorActivo;
    int numAnterior;
    bool moviendo;

    static Generador gen;
    WaitUntil wuEsperar = new WaitUntil(Esperar);

    private void Start()
    {
        segundos = segundosCambio; 
        generadorActivo = 0;
        moviendo = false;
    }

    void Update()
    {
        RestarSegundos();

        if(segundos <= 0.0f && !moviendo)
        {
            moviendo = true;
            StartCoroutine(Mover());
        }
    }

    IEnumerator Mover()
    {
        numAnterior = generadorActivo; //guardar el numero actual del generador

        generadorActivo = Random.Range(0, 4); //Generar un nuevo numero

        while (generadorActivo == numAnterior) //Si el nuevo numero es igual al anterior, generar uno nuevo
        {
            generadorActivo = Random.Range(0, 4);
        }

        gen = generadores[numAnterior].GetComponent<Generador>();

        gen.BajarGenerador(); //Bajar el generador antes de activar el siguiente

        yield return wuEsperar;

        generadores[generadorActivo].SetActive(true);

        generadores[generadorActivo].GetComponent<Generador>().SubirGenerador(); //Subir nuevo generador

        segundos = segundosCambio; //Reiniciar contador

        moviendo = false;
    }

    static bool Esperar()
    {
        return gen.bajando == false;
    }

    void RestarSegundos()
    {
        segundos -= Time.deltaTime;
    }
}
