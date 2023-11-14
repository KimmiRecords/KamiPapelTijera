using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Abuela : NPC
{
    //este script maneja los states y movimientos de la abuela
    //nada que ver con los dialogos. eso esta en el dialoguetrigger


    //creo que solo va a moverse desde ser entregada hasta la mesa.

    [HideInInspector] public bool isDropoff;
    public Transform dropoffPoint;
    public Transform unfoldPoint;


    public Animator anim;

    protected override void Start()
    {
        _fsm = new FiniteStateMachine();
        _fsm.AddState(State.Abuela_Idle, new Abuela_IdleState(_fsm, this));
        _fsm.AddState(State.Abuela_FollowPlayer, new Abuela_FollowPlayerState(_fsm, this));
        _fsm.AddState(State.Abuela_Dropoff, new Abuela_DropoffState(_fsm, this));
        _fsm.ChangeState(State.Abuela_Idle);
    }

    public void GetFolded()
    {
        //Debug.Log("get folded");
        _sr.enabled = false;
    }

    public void GetUnfolded()
    {
        //Debug.Log("get unfolded");
        _sr.enabled = true;
        StartAbuelaDropoff();
    }

    public void StartFollowingPlayer(params object[] parameter)
    {
        isFollowing = true;
        transform.parent = player.transform.parent;
    }
    public void StopFollowingPlayer()
    {
        isFollowing = false;
    }
    public void StartAbuelaDropoff(params object[] parameter)
    {
        isDropoff = true;
    }
    public void PlaceAbuelaAtUnfoldPoint(params object[] parameter)
    {
        transform.parent = unfoldPoint.transform;
        transform.position = unfoldPoint.position;
    }


    //private void OnDestroy()
    //{
    //    if (!gameObject.scene.isLoaded)
    //    {

    //    }
    //}
}
