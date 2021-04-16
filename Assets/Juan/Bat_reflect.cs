using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_reflect : MonoBehaviour
{
    [Header("Bat Layer")]
    public int color_layer; //Bat Layer

    private void Awake()
    {
        color_layer = gameObject.layer; //Assigns current layer as layer to reflect
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (color_layer == collision.collider.gameObject.layer) //Compares the collider layer with color_layer
        {
            if (collision.collider.gameObject.GetComponent<Bala>()) //If the hit object is a bullet
            {
                collision.collider.gameObject.GetComponent<Bala>().reflected = true; //Sets bullet reflected state as true
            }
        }
    }

}

