using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bate_Movimiento : MonoBehaviour
{
    Vector3 playerPos;

    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    void Update()
    {
        //Rotar();
    }

    void Rotar()
    {
        transform.Rotate(Vector3.right * Time.deltaTime, 10.0f);
    }

    void Regresar()
    {
        LeanTween.move(gameObject, playerPos, 1.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Regresar();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
