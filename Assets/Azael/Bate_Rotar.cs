using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bate_Rotar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotar();
    }

    void Rotar()
    {
        transform.Rotate(Vector3.right * Time.deltaTime, 10.0f, Space.Self);
    }
}
