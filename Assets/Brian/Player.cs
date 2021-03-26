using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
        arm1PositionStart.position = arm1.transform.position;
        arm2PositionStart.position = arm2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (!returning)
        {
            if (arm1.transform.position.z != arm1Position.position.z && arm1Moving)
            {
                arm1.transform.Translate(new Vector3(0, 0, -.5f) * Time.deltaTime * 4, Space.World);
            }

            if (arm1.transform.position.z <= arm1Position.position.z)
                arm1Moving = false;
        }
        if (returning)
        {
            if (arm1.transform.position.z != arm1Position.position.z && !arm1Moving)
            {
                arm1.transform.Translate(new Vector3(0, 0, .5f) * Time.deltaTime * 4, Space.Self);
            }
            if (arm1.transform.position.z >= arm1PositionStart.position.z)
                arm1.transform.position = arm1PositionStart.position;
        }
    }

    void RightArm(bool returning)
    {
        if (!returning)
        {
            if (arm2.transform.position.z != arm2Position.position.z && arm2Moving)
            {
                arm2.transform.Translate(new Vector3(0, 0, -.5f) * Time.deltaTime * 4, Space.World);
            }

            if (arm2.transform.position.z <= arm2Position.position.z)
                arm2Moving = false;
        }
        if (returning)
        {
            if (arm2.transform.position.z != arm2Position.position.z && !arm2Moving)
            {
                arm2.transform.Translate(new Vector3(0, 0, .5f) * Time.deltaTime * 4, Space.Self);
            }
            if (arm2.transform.position.z >= arm2PositionStart.position.z)
                arm2.transform.position = arm2PositionStart.position;
        }
    }
}
