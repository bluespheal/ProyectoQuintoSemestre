using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class TorretaIA : Agent
{
    Rigidbody rb;
    public Transform Target;
    public float forceMultiplier = 100;
    public float reward;
    public float valCastigo;
    public float valRecompenza;
    public Transform shootingPoint;
    public int minStepsBetweenShots = 150;
    public float anguloDiferencial;
    public int aciertos;
    public int contador;
    public int fallos;
    public int puntaje;
    private int StepsUntilShotIsAvaliable = 0;
    private bool ShotAvaliable = true;
    public bool aim = false;

    List<GameObject> balas;
    public GameObject balaPref;
    public int balasIni;

    public RayPerceptionSensorComponent3D ojos;
    public Collider[] hitGroundColliders = new Collider[3];
    private void Aim()
    {
        if (!ShotAvaliable)
        {
            StepsUntilShotIsAvaliable--;

            if (StepsUntilShotIsAvaliable <= 0)
                ShotAvaliable = true;

        }
        /*int layerMask = 1 << LayerMask.NameToLayer("Player");
        Vector3 direction = transform.forward;
        Debug.DrawRay(start: shootingPoint.position, dir: direction * 40f, Color.green, duration: 2f);
        //Ojos
        float angle = 360 / 8;
        Quaternion quat = Quaternion.AngleAxis(angle, Vector3.up);
        Vector3 vec = transform.right;
        for (int i = 0; i <= 360; i = i + 45)
        {
            Debug.DrawRay(start: transform.position, dir: vec * 40f, Color.red, duration: 0.5f);
            if (Physics.Raycast(origin: transform.position, vec, out var eyehit, maxDistance: 40f, layerMask))
            {
                Target = eyehit.transform;
            }
            vec = quat * vec;
        }
        //Mira
        
        if (Physics.Raycast(origin: shootingPoint.position, direction, out var hit, maxDistance: 40f, layerMask))
        {           
            SetReward(0.01f);
        }
        else
        {
            SetReward(-0.03f);
        }*/

    }

    public void movimiento(float angulo)
    {
        this.transform.Rotate(0, angulo, 0);
        this.contador++;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        valCastigo = -2.0f;
        valRecompenza = 1.0f;

        balas = new List<GameObject>();
        for (int i = 0; i < balasIni; i++)
        {
            GameObject b = Instantiate(balaPref, null);
            b.GetComponent<Proyectil>().torretin = this;
            b.gameObject.SetActive(false);
            balas.Add(b);
        }
    }

    public override void OnEpisodeBegin()
    {
        aciertos = 0;
        fallos = 0;
        contador = 0;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        //percibir las posiciones del agente y del objetivo
        sensor.AddObservation(this.transform.localRotation);
        sensor.AddObservation(this.Target != null);
        sensor.AddObservation(this.ShotAvaliable);
        if (Target)
        {
            sensor.AddObservation(Target.localPosition);
            sensor.AddObservation(Vector3.Distance(this.transform.position, Target.localPosition));
            sensor.AddObservation(anguloDiferencial);
        }
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        //ojos.RaySensor.Perception();
        SetReward(-0.01f);
        //Vectores de accion
        Aim();
        float controlSignal = 0.0f;
        controlSignal = actionBuffers.DiscreteActions[0];
        int accionDisparo = actionBuffers.DiscreteActions[1];
        dispara(accionDisparo);
        if (Target)
        {
            Vector3 targetDirection = Target.position - transform.position;
            targetDirection.y = 0;
            anguloDiferencial = Vector3.Angle(targetDirection, transform.forward);
            //print(anguloDiferencial);
            if (anguloDiferencial < 10.0f)
            {
                SetReward(0.015f);
                aim = true;
            }
            else if (anguloDiferencial >= 20.0f)
            {
                SetReward(-0.03f);
                aim = false;
            }
            //transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f));
        }
        movimiento(Mathf.Clamp(controlSignal, -5.0f, 5.0f));


        if (ShotAvaliable && aim)
        {
            dispara(1);

        }


        if (contador >= 2400)
        {
            SetReward(-0.1f);
            //contador = 0;
        }

    }

    public void Acertar()
    {
        contador = 0;
        SetReward(1.5f);
        aciertos++;
        if (aciertos >= 5)
        {
            SetReward(valRecompenza);
            valRecompenza++;
            EndEpisode();
        }
    }
    public void Fallar()
    {
        //Debug.Log("fallo");
        SetReward(-2.0f);
        fallos++;
        if (fallos >= 5)
        {
            SetReward(valCastigo);
            valCastigo--;
            EndEpisode();
        }
    }
    public void GiveReward(float _reward)
    {
        SetReward(_reward);
        reward += _reward;
        //RefreshPointsOnCanvas();
    }
    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            dispara();
        }
    }
    */
    void dispara(int accion)
    {
        if (accion == 1 && ShotAvaliable)
        {
            //AddReward(0.02f);
            for (int i = 0; i < balas.Count; i++)
            {
                if (!balas[i].gameObject.activeInHierarchy)
                {
                    balas[i].gameObject.SetActive(true);
                    balas[i].transform.position = shootingPoint.position;
                    balas[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                    balas[i].GetComponent<Rigidbody>().AddForce(transform.forward * forceMultiplier);
                    ShotAvaliable = false;
                    StepsUntilShotIsAvaliable = minStepsBetweenShots;
                    return;
                }
            }
            GameObject b = Instantiate(balaPref, null);
            b.GetComponent<Proyectil>().torretin = this;
            b.transform.position = shootingPoint.position;
            balas.Add(b);
            b.GetComponent<Rigidbody>().AddForce(transform.forward * forceMultiplier);
            ShotAvaliable = false;
            StepsUntilShotIsAvaliable = minStepsBetweenShots;
        }


    }
    public virtual void Regsterkill()
    {
        AddReward(1.0f);
        EndEpisode();
    }
}
