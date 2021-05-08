using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier_item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player") )
        {
            if (!collision.gameObject.GetComponent<PlayerController>().shield)
            {
                collision.gameObject.GetComponent<PlayerController>().shield = true;
                collision.gameObject.GetComponent<PlayerController>().ToggleShield();
                Destroy(gameObject);
            }
        }
    }
}
