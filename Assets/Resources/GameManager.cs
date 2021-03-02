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
        if(tiempoRestante > 0 && !gameover)
        {
            tiempoRestante -= Time.deltaTime;
        }
        if(tiempoRestante <= 0 && !gameover)
        {
            gameover = true;
        }
    }

    public void startGame()
    {
        tiempoRestante = 10;
        gameover = false;
        puntos = 0;
    }

    public void endGame()
    {

    }
}
