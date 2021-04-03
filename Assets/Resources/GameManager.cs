using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager controlador;

    public static float tiempoRestante;
    public static float tiempoTranscurrido;
    public static float puntos;
    public static bool gameover;
    public static List<GameObject> cuentaEnemigos = new List<GameObject>();
    public static GameObject puerta;

    private void Awake()
    {
        if(controlador != null && controlador != this)
        {
            Destroy(gameObject);
            return;
        }
        controlador = this;
        DontDestroyOnLoad(gameObject);

        gameover = true;

    }
    

    void Update()
    {
        
    }

    public void startGame()
    {
        gameover = false;
        puntos = 0;
    }

    public void endGame()
    {

    }

    public static void ContarEnemigo(GameObject enemigo)
    {
        cuentaEnemigos.Add(enemigo);
    }
    public static void DescontarEnemigo(GameObject enemigo)
    {
        cuentaEnemigos.Remove(enemigo);
        if (cuentaEnemigos.Count == 0)
        {
            puerta.SetActive(false);
        }
    }

    public static void ContarPuerta(GameObject _puerta)
    {
        puerta = _puerta;
    }
}
