using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(MeleeMachine))]
public class Estado : MonoBehaviour
{
    //Se encarga de cambiar entre cada estado (script)
    public MeleeMachine agente;
    public List<Transicion> transiciones = new List<Transicion>();
    public NavMeshAgent nav;
    //protected UniversalMovement movementController;
    private void Awake()
    {
        //obtenemos el Objeto que queremos cambiar de estados automaticamente
        agente = GetComponent<MeleeMachine>();
        nav = GetComponent<NavMeshAgent>();
        //movementController = GetComponent<UniversalMovement>();
    }

    public virtual void OnEnable()
    {

    }
    public virtual void OnDisable()
    {

    }

    public virtual void Update()
    {

    }

    private void FixedUpdate()
    {
        foreach (Transicion transition in transiciones)
        {
            //Si se cumple la condicion...
            if (transition.condicion.Test(agente))
            {
                //...Cambia a ese estado (script)...
                transition.objetivo.enabled = true;
                //... y desactiva este
                this.enabled = false;
                return;
            }
        }
    }
    [Serializable]
    public struct Transicion
    {
        public Condiciones condicion;
        public Estado objetivo;
    }
}
