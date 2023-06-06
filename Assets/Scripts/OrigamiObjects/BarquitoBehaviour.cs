using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarquitoBehaviour : MonoBehaviour
{
    FiniteStateMachine _fsm;
    public float speed = 5;
    float maxForce = 5;

    public Node[] allNodes;

    [HideInInspector]
    public Vector3 velocity;
    [HideInInspector]
    public List<Node> _pathToFollow = new List<Node>();
    [HideInInspector]
    public Pathfinding _pf = new Pathfinding();

    public bool playerIsInside;

    float arriveRadius = 0.1f;



    void Start()
    {
        _fsm = new FiniteStateMachine();
        _fsm.AddState(State.BarquitoIdle, new BarquitoIdleState(_fsm, this));
        _fsm.AddState(State.BarquitoMoving, new BarquitoMovingState(_fsm, this));
        _fsm.ChangeState(State.BarquitoIdle);
    }

    void Update()
    {
        //transform.position += velocity * Time.deltaTime;
        _fsm.Update();
    }

    public void AddForce(Vector3 force)
    {
        velocity = Vector3.ClampMagnitude(velocity + force, speed);
    }

    public Node FindClosestNode(Vector3 pos)
    {
        float currentDistance = Mathf.Infinity;
        Node closestNode = default;

        foreach (var node in allNodes)
        {
            float nodeDistance = Vector3.Distance(pos, node.transform.position);

            if (nodeDistance < currentDistance)
            {
                currentDistance = nodeDistance;
                closestNode = node;
            }
        }
        return closestNode;
    }

    public Vector3 Arrive(Vector3 pos)
    {
        Vector3 desired = pos - transform.position;
        if (desired.magnitude <= arriveRadius)
        {
            //estoy dentro del radio, me voy frenando
            float newSpeed = speed * (desired.magnitude / arriveRadius);
            desired.Normalize();
            desired *= newSpeed;
        }
        else
        {
            //seek normal mientras estoy lejos del objeto
            desired.Normalize();
            desired *= speed;
        }

        Vector3 steering = desired - velocity;
        steering = Vector3.ClampMagnitude(steering, maxForce);
        return steering;
    }
}
