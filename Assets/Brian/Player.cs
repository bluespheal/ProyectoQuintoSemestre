using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //Codigo para probar unos testings de colision, no es de importancia y sera borrado despues

    public GameObject arm1;
    public GameObject arm2;
    public Transform arm1Position;
    public Transform arm2Position;
    public Transform arm1PositionStart;
    public Transform arm2PositionStart;
    public bool arm1Moving;
    public bool arm2Moving;

    // Start is called before the first frame update
    void Start()
    {
        //Se guarda la ubicacion inicial de cada brazo
        arm1PositionStart.position = arm1.transform.position;
        arm2PositionStart.position = arm2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Si se hace click con click izq o der, golpear con el correspondiente
        if (Input.GetMouseButtonDown(0))
        {
            arm1Moving = true;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            arm2Moving = true;
        }
        StartCoroutine("ArmsTranslating");
    }

    IEnumerator ArmsTranslating()
    {
        //Funcion para verificar si se esta moviendo un brazo, no se pueda mover otro (Si se puede hacer en el juego, solo probe algo)
        if (arm1Moving)
        {
            LeftArm(false);
            yield return new WaitForSeconds(.5f);
            LeftArm(true);
        }
        if (arm2Moving)
        {
            RightArm(false);
            yield return new WaitForSeconds(.5f);
            RightArm(true);
        }
    }

    void LeftArm(bool returning)
    {
        //Si no esta regresando el brazo, dezplazarlo hasta el punto maximo
        if (!returning)
        {
            if (arm1.transform.position.z != arm1Position.position.z && arm1Moving)
            {
                arm1.transform.Translate(new Vector3(0, 0, -.5f) * Time.deltaTime * 4, Space.World);
            }

            if (arm1.transform.position.z <= arm1Position.position.z)
                arm1Moving = false;
        }
        //Si llego al final, regresarlo
        if (returning)
        {
            if (arm1.transform.position.z != arm1Position.position.z && !arm1Moving)
            {
                arm1.transform.Translate(new Vector3(0, 0, .5f) * Time.deltaTime * 4, Space.Self);
            }
            //Dejarlo en el punto inicial
            if (arm1.transform.position.z >= arm1PositionStart.position.z)
                arm1.transform.position = arm1PositionStart.position;
        }
    }

    void RightArm(bool returning)
    {
        //Si no esta regresando el brazo, dezplazarlo hasta el punto maximo
        if (!returning)
        {
            if (arm2.transform.position.z != arm2Position.position.z && arm2Moving)
            {
                arm2.transform.Translate(new Vector3(0, 0, -.5f) * Time.deltaTime * 4, Space.World);
            }

            if (arm2.transform.position.z <= arm2Position.position.z)
                arm2Moving = false;
        }
        //Si llego al final, regresarlo
        if (returning)
        {
            if (arm2.transform.position.z != arm2Position.position.z && !arm2Moving)
            {
                arm2.transform.Translate(new Vector3(0, 0, .5f) * Time.deltaTime * 4, Space.Self);
            }
            //Dejarlo en el punto inicial
            if (arm2.transform.position.z >= arm2PositionStart.position.z)
                arm2.transform.position = arm2PositionStart.position;
        }
    }
}
