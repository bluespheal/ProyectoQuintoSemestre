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
        sensor.AddObservation(this.aim);
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
        GiveReward(-0.01f);
        //Vectores de accion
        Aim();
        float controlSignal = 0.0f;
        int direction;
        controlSignal = actionBuffers.DiscreteActions[0];
        int accionDisparo = actionBuffers.DiscreteActions[1];
        direction = actionBuffers.DiscreteActions[2];
        //float angle = Mathf.Clamp(controlSignal, 0.0f, 5.0f);
        //Debug.LogError("Angle: " + controlSignal);
        dispara(accionDisparo);
        if (Target)
        {
            Vector3 targetDirection = Target.position - transform.position;
            targetDirection.y = 0;
            anguloDiferencial = Vector3.Angle(targetDirection, transform.forward);
            //print(anguloDiferencial);
            if (anguloDiferencial < 10.0f)
            {
                GiveReward(0.15f);
                aim = true;
            }
            else if (anguloDiferencial >= 10.0f)
            {
                GiveReward(-0.05f);
                aim = false;
            }
            //transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f));
        }

        if (direction == 1)
        {
            movimiento(controlSignal);
        }
        else
        {
            movimiento(controlSignal * -1);
        }

        if (contador >= 2400)
        {
            GiveReward(-0.1f);
            //contador = 0;
        }

    }

    public void Acertar()
    {
        contador = 0;
        GiveReward(2.0f);
        aciertos++;
        if (aciertos >= 5)
        {
            GiveReward(valRecompenza);
            valRecompenza++;
            EndEpisode();
        }
    }
    public void Fallar()
    {
        //Debug.Log("fallo");
        //GiveReward(-3.0f);
        fallos++;
        /*if (fallos >= 5)
        {
            GiveReward(valCastigo);
            valCastigo--;
            EndEpisode();
        }*/
    }
    public void GiveReward(float _reward)
    {
        SetReward(_reward);
        reward += _reward;
    }

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
