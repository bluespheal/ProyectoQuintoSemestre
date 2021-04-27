using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string gameoverScene;

    void Start()
    {
        gameoverScene = "GameOver"; //Default Gameover scene
    }
    public void Gameover()// Changes to Gameover scene when it's called
    {
        SceneManager.LoadScene(gameoverScene);
    }

    public void ChangeLevel(string levelToLoad) //Changes scene to whatever scene is passed into the function
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
