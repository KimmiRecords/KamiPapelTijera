using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GallinaWalkState : IState
{

    FiniteStateMachine _fsm;
    Gallina _gallina;
    private bool goalReached;

    [SerializeField]
    Node currentGoalNode;

    public GallinaWalkState(FiniteStateMachine fsm, Gallina r)
    {
        _fsm = fsm;
        _gallina = r;
    }

    public void OnEnter()
    {
        Debug.Log("gallina - entre a walk");
        //_gallina.anim.SetBool("isWalk", true);
        SetGoal(_gallina);
    }

    public void OnUpdate()
    {
        if (goalReached) //si llego, nuevo camino
        {
            Debug.Log("cambie de goal");
            SetGoal(_gallina);
        }

        _gallina.RotateAccordingly();
        WalkTowardsNode(currentGoalNode, _gallina);

        if (_gallina.playerIsInRange)
        {
            _fsm.ChangeState(State.GallinaEvade);
        }
        //_gallina.transform.position += _gallina.velocity * Time.deltaTime;
    }

    public void OnExit()
    {
        //Debug.Log("salgo de walk");
        Debug.Log("gallina - entre a walk");
    }

    public void SetGoal(Gallina yo)
    {
        Debug.Log("gallina - arranca set goal");
        currentGoalNode = yo.allNodes[Random.Range(0, yo.allNodes.Length)];
        goalReached = false;
    }
    
    public void WalkTowardsNode(Node goalNode, Gallina yo)
    {
        Vector3 dir = goalNode.transform.position - yo.transform.position;
        dir.y = 0;
        yo.transform.position += yo.Speed * Time.deltaTime * dir.normalized;

        if (dir.magnitude < yo.arriveRadius*2)
        {
            Debug.Log("llegue al node");
            goalReached = true;
        }
    }
}
