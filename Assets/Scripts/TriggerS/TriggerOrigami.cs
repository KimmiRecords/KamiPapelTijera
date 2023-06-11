using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOrigami : TriggerScript
{
    //cuando entras a este trigger hace nacer al origamicheck
    //el origami check se va a encargar de chequear que apretes tab y hagas el origami

    public Origami origami;
    
    public MultipleRectCheck checkPrefab;
    MultipleRectCheck currentCheck;

    protected override void Start()
    {
        base.Start();
    }

    public override void OnEnterBehaviour(Collider other)
    {
        //print("on enter beh");
        if (!origami.wasUsed)
        {
            if (LevelManager.instance.recursosRecolectados[ResourceType.papel] >= origami.paperCost)
            {
                base.OnEnterBehaviour(other);
                currentCheck = Instantiate(checkPrefab).SetOrigami(origami);
                //particulas y sonidito de entrar en la zona
            }
            else
            {
                print("no tenes suficiente papel para hacer este origami");
            }
            
        }
        else
        {
            print("ya activaste este sello");
        }
    }

    public override void OnExitBehaviour()
    {
        //print("on exit beh");

        if (currentCheck != null)
        {
            base.OnExitBehaviour();
            currentCheck.EndOrigami(origami);
            Destroy(currentCheck.gameObject);
            //apagar particulas y sonidito de salir en la zona
        }
    }
}
