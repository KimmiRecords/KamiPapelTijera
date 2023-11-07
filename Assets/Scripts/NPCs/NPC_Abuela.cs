using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Abuela : NPC
{
    //este script maneja los states y movimientos de la abuela
    //nada que ver con los dialogos. eso esta en el dialoguetrigger


    //creo que solo va a moverse desde ser entregada hasta la mesa.

    [HideInInspector] public bool isDropoff;
    [HideInInspector] public Vector3 dropoffPoint;

    public Animator anim;

    protected override void Start()
    {
        _fsm = new FiniteStateMachine();
        _fsm.AddState(State.Abuela_Idle, new Abuela_IdleState(_fsm, this));
        _fsm.AddState(State.Abuela_FollowPlayer, new Abuela_FollowPlayerState(_fsm, this));
        _fsm.AddState(State.Abuela_Dropoff, new Abuela_DropoffState(_fsm, this));
        _fsm.ChangeState(State.Abuela_Idle);
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
        if (parameter[0] is Transform)
        {
            Transform dropOffTransform = (Transform)parameter[0];
            dropoffPoint = dropOffTransform.position;
            transform.parent = dropOffTransform;
        }
    }
    public void PlaceAbuelaNextToPlayer(params object[] parameter)
    {
        if (isFollowing)
        {
            transform.position = player.transform.position + (player.transform.forward * (playerOffsetDistance / 2));
        }
    }

    //private void OnDestroy()
    //{
    //    if (!gameObject.scene.isLoaded)
    //    {
            
    //    }
    //}
}
