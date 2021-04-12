using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Se crea una referencia para el mismo
    static GameManager instance;

    public float tiempoRestante;
    public float tiempoTranscurrido;
    public float puntos;
    public bool gameover;
    public List<GameObject> cuentaEnemigos = new List<GameObject>();
    public GameObject puerta;
    //Se hace un getter a la referencia para que se pueda acceder facilmente desde otros scripts 
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        //Si ya existe otro Game Manager se autodestruye
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        //Se referencia a si mismo
        instance = this;
        //Se le dice que no se destruya entre escenas
        DontDestroyOnLoad(gameObject);
    }
    

    void Update()
    {
        
    }

    public void startGame()
    {
        //Condiciones para cuando inicia el juego (Placeholders de momento)
        gameover = false;
        puntos = 0;
    }

    public void endGame()
    {
        //Condiciones para cuando termina el juego 
    }
    //Funcion que llaman los enemigos de cada nivel al crearse para que el GM los pueda contar
    public void ContarEnemigo(GameObject enemigo)
    {
        cuentaEnemigos.Add(enemigo);
    }
    //Funcion que llaman los enemigos de cada nivel al morir para que el GM los pueda contar
    public void DescontarEnemigo(GameObject enemigo)
    {
        cuentaEnemigos.Remove(enemigo);
        if (cuentaEnemigos.Count == 0)
        {
            puerta.SetActive(false);
        }
    }
    //Funcion que llama la puerta de cada nivel al crearse para que el GM sepa cual abrir (Cambiar para que en el futuro ejecute una animacion)
    public void ContarPuerta(GameObject _puerta)
    {
        puerta = _puerta;
    }
}
