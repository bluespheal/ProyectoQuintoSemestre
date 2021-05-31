using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathRain : MonoBehaviour
{
    public int deaths;
    public GameObject skull;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < deaths; i++)
        {
            Instantiate(skull, new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y + Random.Range(0, 7), transform.position.z + Random.Range(-3, 3)), Quaternion.identity);
        }

    }
}
