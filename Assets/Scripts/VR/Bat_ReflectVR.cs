using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_ReflectVR : MonoBehaviour
{
    [Header("Bat Layer")]
    public int color_layer; //Bat Layer
    public Transform player;
    Vector3 goal;

    private void Start()
    {
        color_layer = gameObject.layer; //Assigns current layer as layer to reflect
        player = GameObject.Find("PlayerCamera").GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        goal = player.eulerAngles;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (color_layer == collision.collider.gameObject.layer) //Compares the collider layer with color_layer
        {
            if (collision.collider.gameObject.GetComponent<Bala>()) //If the hit object is a bullet
            {
                collision.collider.gameObject.GetComponent<Bala>().Reflejar(goal);
                collision.collider.gameObject.GetComponent<Bala>().reflected = true; //Sets bullet reflected state as true
            }
        }
    }
}
