using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaNivel : MonoBehaviour
{
    private void Awake()
    {
        GameManager.ContarPuerta(this.gameObject);
        Debug.Log(this.gameObject);
    }
}