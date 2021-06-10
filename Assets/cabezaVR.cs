using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabezaVR : MonoBehaviour
{
    public PlayerControllerVR cabeza;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Danger")) // If colides with a "Danger" Tagged object, it dies
        {
            cabeza.Die();
        }
    }
}
