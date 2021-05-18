using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool nivelCargado;
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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        print(scene.name);
        if(scene.name == "GameOver" || scene.name == "Menu")
        {
            return;
        }
        else
        {
            puerta = GameObject.FindGameObjectWithTag("Puerta");
            puerta.GetComponent<MeshRenderer>().enabled = true;
            puerta.GetComponent<BoxCollider>().enabled = true;
            ///nivelCargado = true;
        }

    }
    private void OnDestroy()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
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
        cuentaEnemigos.Clear();
        gameover = true;
        //Condiciones para cuando termina el juego
    }
    //Funcion que llaman los enemigos de cada nivel al crearse para que el GM los pueda contar
    public void ContarEnemigo(GameObject enemigo)
    {
        cuentaEnemigos.Add(enemigo);
        Debug.Log(cuentaEnemigos.Count);
    }
    //Funcion que llaman los enemigos de cada nivel al morir para que el GM los pueda contar
    public void DescontarEnemigo(GameObject enemigo)
    {
        cuentaEnemigos.Remove(enemigo);
        //Debug.Log("Descontando");
        //Debug.Log(cuentaEnemigos.Count);
        if (cuentaEnemigos.Count == 0/* && nivelCargado*/)
        {
            Debug.Log("Nivel Terminado");
            puerta.GetComponent<MeshRenderer>().enabled = false;
            puerta.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
