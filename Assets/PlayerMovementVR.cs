using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementVR : MonoBehaviour
{

    [Header("Camera variables")]
    public Camera cam;
    public float camRotationX = 0f;
    public float currentCamRotationX;
    public float camRotLimit = 45f; //Limits Camera rotation

    public PlayerController player;
    public Rigidbody rb;

    private Vector3 finalVel = Vector3.zero;
    private Vector3 rotation = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        onMove(); //When the player moves
        onRotation();//When the camera moves
    }

    public void Move(Vector3 velocity)
    {
        finalVel = velocity; //Calculates player movement with the Vector3 passed
    }

    public void rotate(Vector3 rotateVector)
    {
        rotation = rotateVector; //Calculates rotation with Vector3 passed
    }

    public void rotateCam(float camRotVector)
    {
        camRotationX = camRotVector; //Calculates camera rotation with Vector3 passed
    }

    void onMove()
    {
        if(finalVel != Vector3.zero) //If movement Vector is not equal to 0
        {
            rb.MovePosition(rb.position + finalVel * Time.fixedDeltaTime);//Calculates RB position
            player.moving = true;//Tells player that is moving
        } else
        {
            player.moving = false;//Tells player that is not moving
        }

    }

    void onRotation() //If the player is rotating
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation)); //Changes rotation with the calculated rotation
        currentCamRotationX -= camRotationX; //Adjusts rotation with the CamRotationX
        currentCamRotationX = Mathf.Clamp(currentCamRotationX, -camRotLimit, camRotLimit); //Limits the vaule between the 2 given values
        cam.transform.localEulerAngles = new Vector3(currentCamRotationX, 0f, 0f); //Changes camera x rotation
    }
}
