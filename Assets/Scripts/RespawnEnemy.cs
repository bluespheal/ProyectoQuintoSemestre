using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemy : MonoBehaviour
{
    public GameObject miEnemigo;
    public Transform spawnPoint;
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
        if(collision.transform.CompareTag("bateRojo")|| collision.transform.CompareTag("bateAzul"))
        {
            if (!miEnemigo.activeInHierarchy)
            {
                miEnemigo.SetActive(true);
                miEnemigo.transform.position = spawnPoint.position;
            }
        }
    }
}
