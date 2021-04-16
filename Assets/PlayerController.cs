using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
   

    [Header("Input variables")]
    public InputMaster controls;
    public PlayerMovement motor;

    [Header("Scene Changer")]
    public SceneChanger sceneChanger;

    [Header("Player and Camera Speeds")]
    public float speed;
    public float lookSpeed;

    [Header("States")]
    public bool alive;

    [Header("Fade")]
    public GameObject fader;
    public float fadeTimer;


    [Header("View references")]
    public Light globalLight1;
    public Light globalLight2;
    public Camera cam;

    [Header("Timer variables")]
    public float timer;
    public bool moving;
    public float timerWinRate;
    public float timerLoseRate;

    [Header("Animation")]
    public Animator playerAnimator;

    [Header("Hitbox")]
    public float hitboxTime;
    public GameObject leftHitbox;
    public GameObject rightHitbox;


    [Header("Ragdoll Parts List")]
    public List<Collider> ragdollParts = new List<Collider>();

    [Header("Lanzar Armas")]
    public GameObject bateAzul_prefab;
    public GameObject bateRojo_prefab;
    public Transform lanzamientoPos; //De donde saldra el arma
    public Image haircross;
    public float fuerza;

    //Player and Camera movement vectors
    Vector2 moveInput;
    Vector2 lookInput;
    private Rigidbody rb;

    //Post-processing settings
    private Volume vol;
    private ColorAdjustments colors;

    private void Awake()
    {
        //Assign initial values for certain variables.
        rb = gameObject.GetComponent<Rigidbody>();
        alive = true;
        playerAnimator = gameObject.GetComponent<Animator>();
        motor = GetComponent<PlayerMovement>();

        //Inputs
        controls = new InputMaster();
        controls.Player.LeftArm.performed += context => LeftArm();
        controls.Player.RightArm.performed += context => RightArm();

        controls.Player.LanzarIzq.started += context => Apuntar();
        controls.Player.LanzarIzq.canceled += context => Lanzar(bateRojo_prefab);

        controls.Player.LanzarDer.started += context => Apuntar();
        controls.Player.LanzarDer.canceled += context => Lanzar(bateAzul_prefab);

        vol = cam.GetComponent<Volume>();//gets Volume of camera for Post-processing
        vol.profile.TryGet(out colors); //assigns var colors the vol profile

        SetRagdollParts();
        
    }

    private void Start()
    {

    }

    private void SetRagdollParts()
    {
        Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();//Inits collider array

        foreach (Collider collider in colliders) // Iterates colliders and fills ragdollParts with them
        {
            if (collider.gameObject != this.gameObject)//Deactivates ragdoll colliders until needed
            {
                collider.isTrigger = true;
                ragdollParts.Add(collider);
            }
        }
    }

    private void TurnOnRagdoll()// Turns on Ragdoll physics
    {
        rb.useGravity = false;
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false; //deactivates this object collider
        foreach(Collider collider in ragdollParts) //Activates colliders for Ragdoll parts and sets their speed to 0
        {
            collider.isTrigger = false;
            collider.attachedRigidbody.velocity = Vector3.zero;
        }
    }

    private void Update()
    {
        if (alive) // While the player is alive
        {
            moveInput = controls.Player.Move.ReadValue<Vector2>(); //Gets vectors for player movement
            motor.Move(getFinalVel(moveInput.x, moveInput.y)); //Passes on movement Vectors

            lookInput = controls.Player.Mouse.ReadValue<Vector2>(); //Gets vectors for Camera control
            Vector3 yRot = new Vector3(0f, lookInput.x, 0f) * lookSpeed; //asigns Vector 2 values into a Vector 3
            motor.rotate(yRot); // Passes on camera Vectors

            float xCamRot = lookInput.y * lookSpeed; //Calculates X camera rotation 
            motor.rotateCam(xCamRot); // Passes on Camera rotation value

            if (timer <= 0) { // If timer reaches 0, you lose
                alive = false;
            }
        }
        else //When player loses
        {
            rb.constraints = RigidbodyConstraints.None; //Enables player rotation
            playerAnimator.enabled = false; //Deactivates animator for Ragdoll physics
            TurnOnRagdoll(); //Activates ragdoll physics
            rb.velocity = Vector3.zero;
            StartCoroutine(FadeOut(fadeTimer));
        }

        //Code that changes the light intensity according to the timer
        globalLight1.intensity = timer / 100;
        globalLight2.intensity = timer / 100;
        //Code that changes the camera's saturation, a bit memory intensive.
        //colors.saturation.value = timer -100;

        if (moving) //If the player is moving, timer increases, else timer decreases
        {
            timer += timerWinRate;
        } else
        {
            timer -= timerLoseRate;
        }
 
        if (timer > 100)// Limits timer to have a max of 100
        {
            timer = 100;
        }

        //Al presionar el boton se enciende la mira y al soltarlo de lanza el arma
        
    }

    //Lanzar bate
    public void Lanzar(GameObject _bate)
    {
        haircross.enabled = false;
        GameObject bate = Instantiate(_bate, lanzamientoPos.position, lanzamientoPos.localRotation);
        Rigidbody rb = bate.GetComponent<Rigidbody>();
        rb.AddForce(this.transform.forward * fuerza, ForceMode.Impulse);
    }

    public void Apuntar()
    {
        haircross.enabled = true;
    }

    Vector3 getFinalVel(float x_axis, float z_axis) //Calculates movement vectors in the correct axes
    {
        Vector3 moveFront = transform.right * x_axis;
        Vector3 moveSide = transform.forward * z_axis;
        Vector3 finalVel = (moveFront + moveSide) * speed;
        return finalVel;
    }


    private void OnEnable() //Enables input control
    {
        controls.Enable();
    }

    private void OnDisable() // Disables input control
    {
        controls.Disable();
    }

    public void LeftArm() //Code that runs when the left arm action is triggered
    {
        if (alive)
        {
            playerAnimator.SetTrigger("Left");
            EnableHitbox(leftHitbox); // Enables the left hitbox for a brief moment
        }
    }

    public void RightArm() //Code that runs when the right arm action is triggered
    {
        if (alive)
        {
            playerAnimator.SetTrigger("Right");
            EnableHitbox(rightHitbox);// Enables the right hitbox for a brief moment
        }
    }

    public void EnableHitbox(GameObject hitbox)//Enables the hitbox passed for a brief second
    {
        hitbox.SetActive(true);
        StartCoroutine(DeactivateHitbox(hitboxTime, hitbox)); // Disables the passed hitbox after a set time.
    }

    private IEnumerator DeactivateHitbox(float waitTime, GameObject hitbox)// Disables the passed hitbox after a set time.
    {
        yield return new WaitForSeconds(waitTime);
        hitbox.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Danger")) // If colides with a "Danger" Tagged object, it dies
        {
            alive = false;
        }
    }

    private IEnumerator FadeOut(float fadeTime) //
    {
        yield return new WaitForSeconds(fadeTime);
        Fade();
        sceneChanger.Gameover();
    }

    // Functions imported from Mirror proyect


    public void Fade()
    {
        fader.GetComponent<Animator>().SetTrigger("Fade");
    }

}
