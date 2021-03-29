using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class UniversalMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 1f;
    public float rotationTime = 0.5f;
    protected virtual void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    public virtual void Move(Vector3 globalDirection)
    {
        if (globalDirection.Equals(Vector3.zero))
        {
            return;
        }
        //Debug.Log(globalDirection);
        Vector3 direction = transform.right * globalDirection.x + transform.forward * globalDirection.z;
        
        controller.SimpleMove(direction * speed);
        if (globalDirection.z == -1 && globalDirection.x == 0)
            return;
        Rotate(direction.normalized);

    }

    public virtual void Rotate(Vector3 direction)
    {
        if (direction.magnitude != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction.normalized), rotationTime);
        };
    }
}
