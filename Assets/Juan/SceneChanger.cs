using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string gameoverScene;
    public bool givesPoints = false;
    public GameManager gamemanager;

    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameoverScene = "GameOver"; //Default Gameover scene
    }
    public void Gameover()// Changes to Gameover scene when it's called
    {
        SceneManager.LoadScene(gameoverScene);
        GameManager.Instance.endGame();
        gamemanager.puntos = 0;
    }

    public void ChangeLevel(string levelToLoad) //Changes scene to whatever scene is passed into the function
    {
        if (givesPoints)
        {
            gamemanager.puntos++;
        }
        if (gamemanager.puntos >= 4)
        {
            SceneManager.LoadScene("Jefazo");
        }
        else
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
