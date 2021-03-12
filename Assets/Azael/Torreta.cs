using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    public GameObject posicionBala;
    public GameObject posicionRayo;

    public GameObject prefab_bala_azul;
    public GameObject prefab_bala_rojo;

    public float cadencia = 1.5f;

    public LayerMask detection;

    void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            posicionRayo.transform.LookAt(other.transform);
            posicionRayo.transform.rotation = Quaternion.Euler(0.0f, posicionRayo.transform.localEulerAngles.y, posicionRayo.transform.localEulerAngles.z);
            transform.LookAt(other.transform);
            transform.rotation = Quaternion.Euler(0.0f, transform.localEulerAngles.y, transform.localEulerAngles.z); //Bloquear rotación X
            Detection();
        }
    }

    private void Detection()
    {
        RaycastHit hit;

        Ray direction = new Ray(posicionRayo.transform.position, posicionRayo.transform.forward);

        if (Physics.Raycast(direction, out hit, 20f, detection))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                cadencia -= Time.deltaTime;
                if (cadencia <= 0.0f)
                {
                    Shoot();
                    cadencia = 1.5f;
                }
            }
            else
            {
                cadencia = 1.5f;
            }
        }
    }


    private void OnGUI()
    {
        Debug.DrawRay(posicionRayo.transform.position, posicionRayo.transform.forward * 15, Color.red);
    }

    public void Shoot()
    {
        GameObject bala;
        int randNum = Random.Range(0, 20);

        if(randNum < 10)
        {
            bala = prefab_bala_azul;
        }
        else
        {
            bala = prefab_bala_rojo;
        }
        
        Instantiate(bala, posicionBala.transform.position, posicionBala.transform.rotation);
    }

}
