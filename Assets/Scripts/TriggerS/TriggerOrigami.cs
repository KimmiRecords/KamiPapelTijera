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
        //EventManager.Subscribe(Evento.OnOrigamiApplied, ConsumirSello);
    }

    //public void ConsumirSello(params object[] parameters) //este se dispara cuando el origami confirma que fue invocado
    //{
    //    if (origami == (Origami)parameters[1])
    //    {
    //        wasUsed = true;
    //    }
    //}

    public override void OnEnterBehaviour(Collider other)
    {
        //print("on enter beh");
        if (!origami.wasUsed)
        {
            if (other.GetComponent<Player>() != null)
            {
                Player player = other.GetComponent<Player>(); //me quedo tranqui xq onenterbehavior solo sucede si el other es player
            
                if (player.Papel >= origami.paperCost)
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
            Destroy(currentCheck);
            //apagar particulas y sonidito de salir en la zona
        }
    }

    //protected override void OnDestroy()
    //{
    //    if (!gameObject.scene.isLoaded)
    //    {
    //        EventManager.Unsubscribe(Evento.OnPlayerPressedE, Interact);
    //        //EventManager.Unsubscribe(Evento.OnOrigamiApplied, ConsumirSello);
    //    }
    //}
}
