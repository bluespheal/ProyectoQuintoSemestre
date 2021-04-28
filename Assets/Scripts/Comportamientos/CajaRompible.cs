using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaRompible : MonoBehaviour
{
    public GameObject Roto;
    public float FuerzaExplosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Rompete();
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("danger"))
        {
            Rompete();
        }
    }

    void Rompete()
    {
        GameObject cajarota = Instantiate(Roto, transform.position, transform.rotation); 
        foreach(Rigidbody rb in cajarota.GetComponentsInChildren<Rigidbody>())
        {
            Vector3 fuerza = (rb.transform.position - transform.position).normalized * FuerzaExplosion;
            rb.AddForce(fuerza);
        }
        Destroy(gameObject);
    }
}
