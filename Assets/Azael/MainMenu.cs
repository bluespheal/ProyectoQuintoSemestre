using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject options;
    GameObject mainMenu;

    void Start()
    {
        mainMenu = this.gameObject;    
    }

    public void ActiveOptions()
    {
        options.GetComponent<Animator>().SetBool("Transition", false);
        //mainMenu.SetActive(false);
        options.SetActive(true);
    }

    public void ActiveMainMenu()
    {
        options.GetComponent<Animator>().SetBool("Transition", true);
        //mainMenu.SetActive(true);
        //options.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        //Cargar el nivel 1
    }
}
