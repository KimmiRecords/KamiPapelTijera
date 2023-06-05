using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOrigami : TriggerScript
{
    //cuando entras a este trigger hace nacer al origamicheck
    //el origami check se va a encargar de chequear que apretes tab y hagas el origami

    public Origami origami;

    public OrigamiCheck checkPrefab;
    OrigamiCheck currentCheck;

    public override void OnEnterBehaviour(Collider other)
    {
        //print("on enter beh");

        base.OnEnterBehaviour(other);
        //particulas y sonidito de entrar en la zona

        currentCheck = Instantiate(checkPrefab).SetOrigami(origami);
        
    }

    public override void OnExitBehaviour()
    {
        //print("on exit beh");

        base.OnExitBehaviour();
        //apagar particulas y sonidito de entrar en la zona
        currentCheck.EndOrigami(origami);
        Destroy(currentCheck);

    }
}
