using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button ng;
    public Button back;
    public GameObject options;
    public GameObject mainMenu;
    public int index;
    public int maxIndex;

    WaitForSecondsRealtime esperar = new WaitForSecondsRealtime(0.2f);

    void Start()
    {
        ng.Select();
    }

    public void ActiveOptions()
    {
        StartCoroutine(ActivarOP());
    }

    public void ActiveMainMenu()
    {
        StartCoroutine(ActivarMM());
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        //Cargar el nivel 1
    }

    IEnumerator ActivarOP()
    {
        options.SetActive(true);
        yield return esperar;
        options.GetComponent<Animator>().SetBool("Transition", false);
        yield return esperar;
        mainMenu.SetActive(false);
        back.Select();
    }

    IEnumerator ActivarMM()
    {
        options.GetComponent<Animator>().SetBool("Transition", true);
        mainMenu.SetActive(true);
        yield return esperar;
        options.SetActive(false);
        ng.Select();
    }
}
