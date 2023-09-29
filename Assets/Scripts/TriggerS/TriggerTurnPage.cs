using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTurnPage : TriggerScript
{
    [SerializeField] PositionMarker _positionMarker;

    public override void OnEnterBehaviour(Collider other)
    {
        base.OnEnterBehaviour(other);
        _positionMarker.ShowMarker();
    }

    private void OnTriggerStay(Collider other)
    {
        if (triggerBool)
        {
            _positionMarker.SetMarkerPosition(LevelManager.Instance.player.transform.position);
        }
    }


    public override void OnExitBehaviour()
    {
        base.OnExitBehaviour();
        _positionMarker.HideMarker();
    }
}
