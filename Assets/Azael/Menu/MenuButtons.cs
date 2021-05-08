using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuButtons : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public Animator animator;
    public Button btn;

    WaitForSecondsRealtime esperar = new WaitForSecondsRealtime(0.1f);

    void Start()
    {
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        StartCoroutine(Press());
    }

    public void OnSelect(BaseEventData eventData)
    {
        animator.SetBool("selected", true);
        animator.SetBool("deselected", false);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        animator.SetBool("deselected", true);
        animator.SetBool("selected", false);

    }

    IEnumerator Press()
    {
        animator.SetBool("press", true);
        yield return esperar;
        animator.SetBool("press", false);
    }
}
