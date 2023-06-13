using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallina : Enemy
{
    //este script tiene que estar en donde esta el animator
    //asi las animaciones pueden llamar a metodos de este script.
    //unity, no lo entenderias.

    public Animator anim; //mi animator

    [HideInInspector]
    public bool startAnimationHasFinished = false; //si el player ya se acerco y me despertó

    [HideInInspector]
    public Player _player;
    protected FiniteStateMachine fsm;

    float maxForce = 5;

    public Node[] allNodes;

    [HideInInspector]
    public Vector3 velocity;
    [HideInInspector]
    public List<Node> _pathToFollow = new List<Node>();
    [HideInInspector]
    public Pathfinding _pf = new Pathfinding();
    public float arriveRadius = 0.1f;
    public float exitDistance = 30;

    [HideInInspector]
    public bool playerIsInRange;

    private void Start()
    {
        fsm = new FiniteStateMachine();
        fsm.AddState(State.GallinaWalk, new GallinaWalkState(fsm, this));
        fsm.AddState(State.GallinaEvade, new GallinaEvadeState(fsm, this));
        fsm.ChangeState(State.GallinaWalk);
    }

    private void Update()
    {
        fsm.Update();
    }

    public void AddForce(Vector3 force)
    {
        velocity = Vector3.ClampMagnitude(velocity + force, Speed);
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
            float newSpeed = Speed * (desired.magnitude / arriveRadius);
            desired.Normalize();
            desired *= newSpeed;
        }
        else
        {
            //seek normal mientras estoy lejos del objeto
            desired.Normalize();
            desired *= Speed;
        }

        Vector3 steering = desired - velocity;
        steering = Vector3.ClampMagnitude(steering, maxForce);
        return steering;
    }

    public void RotateAccordingly()
    {
        //depende del velocity, ojota
        if (velocity.x > transform.position.x) //roto al enemy segun pa donde camine
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
