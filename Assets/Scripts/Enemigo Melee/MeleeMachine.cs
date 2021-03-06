using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeMachine : MonoBehaviour
{
    public GameObject target;
    public Collider arma;
    public GameObject weapon;
    public Animator anim;
    public Rigidbody rb;
    public bool meleeRange;
    public bool attacking;
    public bool muerto;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //GameManager.Instance.ContarEnemigo(this.gameObject);
    }

    private void FixedUpdate()
    {
        if (target)
        {
            if (Vector3.Distance(target.transform.position, gameObject.transform.position) <= 1.5f)
            {
                meleeRange = true;
            }
            else
                meleeRange = false;
        }
        else
            meleeRange = false;
        /*if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.DescontarEnemigo(this.gameObject);
            Destroy(this.gameObject);
        }*/
    }
}
