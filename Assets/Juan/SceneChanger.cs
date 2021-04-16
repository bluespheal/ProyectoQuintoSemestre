using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string gameoverScene;

    void Start()
    {
        gameoverScene = "GameOver";
    }
    public void Gameover()
    {
        SceneManager.LoadScene(gameoverScene);
    }

    public void ChangeLevel(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
