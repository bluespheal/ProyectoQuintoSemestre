using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Unity.MLAgents;
using Unity.Barracuda;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using System.Collections.Generic;

public class AgentShield : Agent
{
    Rigidbody m_AgentRb;
    Quaternion currentRotation;
    Vector3 eulerRotation;
    public float rotationSpeed = 3;
    public int currentHealth;
    int maxHealth = 3;
    public int indexDestroyedBats;
    public float reward;
    public Text points;
    public GameObject player;

    [SerializeField] public List<Transform> bulletsList = new List<Transform>();

    public override void OnEpisodeBegin()
    {
        Initialize();
    }

    public override void Initialize()
    {
        currentHealth = maxHealth;
        m_AgentRb = GetComponent<Rigidbody>();
        eulerRotation = Vector3.zero;
        currentRotation.eulerAngles = eulerRotation;
        transform.rotation = currentRotation;
        indexDestroyedBats = 0;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;
        //discreteActions[0] = Input.GetAxisRaw()
    }

    public void movimiento(float angulo)
    {
        this.transform.Rotate(0, angulo, 0);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        int controlSignal;
        int direction;
        controlSignal = actions.DiscreteActions[0];
        direction = actions.DiscreteActions[1];
        /*float rotationY = actions.DiscreteActions[0];

        eulerRotation = new Vector3(0, rotationY, 0) * Time.deltaTime * rotationSpeed * 10;
        currentRotation.eulerAngles = eulerRotation;

        transform.rotation = currentRotation;*/
        if(direction == 1)
        {
            movimiento(controlSignal);
        }
        else
        {
            movimiento(controlSignal * -1);
        }

        if (currentHealth <= 0)
        {

            GiveReward(-5);
            EndEpisode();
        }
        if(indexDestroyedBats >= 6)
        {
            GiveReward(5);
            EndEpisode();
        }
        GiveReward(-0.0005f);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.rotation);
        sensor.AddObservation(player.transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollisionDetected(TurretCollider collision)
    {
        GiveReward(-2.5f);
        currentHealth--;
    }
    public void CollisionDetectedShield(ShielCollider collision)
    {
        GiveReward(3.5f);
        indexDestroyedBats++;
    }

    public void RefreshPointsOnCanvas()
    {
        points.text = reward.ToString();
    }

    public void GiveReward(float _reward)
    {
        SetReward(_reward);
        reward += _reward;
        RefreshPointsOnCanvas();
    }

}
