using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Abuela : NPC
{
    [HideInInspector]
    public bool isDropoff;
    [HideInInspector]
    public Vector3 dropoffPoint;


    protected override void Start()
    {
        _fsm = new FiniteStateMachine();
        _fsm.AddState(State.Abuela_Idle, new Abuela_IdleState(_fsm, this));
        _fsm.AddState(State.Abuela_FollowPlayer, new Abuela_FollowPlayerState(_fsm, this));
        _fsm.AddState(State.Abuela_Dropoff, new Abuela_DropoffState(_fsm, this));
        _fsm.ChangeState(State.Abuela_Idle);
        EventManager.Subscribe(Evento.OnDialogueEnd, StartFollowingPlayer);
        EventManager.Subscribe(Evento.OnPlayerPlaced, PlaceAbuelaNextToPlayer);
        EventManager.Subscribe(Evento.OnAbuelaDropoff, StartAbuelaDropoff);
    }

    public void StartFollowingPlayer(params object[] parameter)
    {
        if (parameter[1] is Dialogue d)
        {
            if (d.name == "Abuela_01")
            {
                isFollowing = true;
                transform.parent = player.transform.parent;
            }
        }
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
            var dropOffTransform = (Transform)parameter[0];
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

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnDialogueEnd, StartFollowingPlayer);
            EventManager.Unsubscribe(Evento.OnPlayerChangePage, PlaceAbuelaNextToPlayer);
            EventManager.Unsubscribe(Evento.OnAbuelaDropoff, StartAbuelaDropoff);

        }
    }
}
