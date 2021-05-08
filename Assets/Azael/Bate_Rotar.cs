using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bate_Rotar : MonoBehaviour
{
    void Update()
    {
        Rotar();
    }

    void Rotar()
    {
        transform.Rotate(Vector3.right * Time.deltaTime, 10.0f, Space.Self);
    }
}
