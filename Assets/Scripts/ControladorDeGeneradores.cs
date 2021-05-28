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

    private void Start()
    {
        segundos = segundosCambio; 
        generadorActivo = 0;
    }

    void Update()
    {
        RestarSegundos();

        if(segundos <= 0.0f)
        {
            segundos = segundosCambio; //Reiniciar contador

            numAnterior = generadorActivo; //guardar el numero actual del generador

            generadores[numAnterior].GetComponent<Generador>().BajarGenerador(); //Bajar el generador antes de activar el siguiente

            generadorActivo = Random.Range(0, 4); //Generar un nuevo numero

            while(generadorActivo == numAnterior) //Si el nuevo numero es igual al anterior, generar uno nuevo
            {
                generadorActivo = Random.Range(0, 4);
            }

            while(generadores[numAnterior].GetComponent<Generador>().bajando == true) //Si el generador anterior ya terminó de bajar
            {
            }
            generadores[generadorActivo].GetComponent<Generador>().SubirGenerador(); //Subir nuevo generador
        }
    }

    IEnumerator Mover()
    {
        segundos = segundosCambio; //Reiniciar contador

        numAnterior = generadorActivo; //guardar el numero actual del generador

        generadores[numAnterior].GetComponent<Generador>().BajarGenerador(); //Bajar el generador antes de activar el siguiente

        generadorActivo = Random.Range(0, 4); //Generar un nuevo numero

        while (generadorActivo == numAnterior) //Si el nuevo numero es igual al anterior, generar uno nuevo
        {
            generadorActivo = Random.Range(0, 4);
        }

        yield return new WaitUntil(() => generadores[numAnterior].GetComponent<Generador>().bajando == false);

        generadores[generadorActivo].GetComponent<Generador>().SubirGenerador(); //Subir nuevo generador
    }

    void RestarSegundos()
    {
        segundos -= Time.deltaTime;
    }
}
