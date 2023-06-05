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
    public int paperCost;

    bool wasUsed = false;

    protected override void Start()
    {
        base.Start();
        EventManager.Subscribe(Evento.OnOrigamiApplied, UsarSello);
    }

    public void UsarSello(params object[] parameters)
    {
        if (origami == (Origami)parameters[1])
        {
            wasUsed = true;
        }
    }

    public override void OnEnterBehaviour(Collider other)
    {
        //print("on enter beh");
        if (!wasUsed)
        {
            if (other.GetComponent<Player>() != null)
            {
                Player player = other.GetComponent<Player>(); //me quedo tranqui xq onenterbehavior solo sucede si el other es player
            
                if (player.Papel >= paperCost)
                {
                    base.OnEnterBehaviour(other);
                    currentCheck = Instantiate(checkPrefab).SetOrigami(origami, paperCost, wasUsed);
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
            //apagar particulas y sonidito de entrar en la zona
        }
    }

    protected override void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerPressedE, Interact);
            EventManager.Unsubscribe(Evento.OnOrigamiApplied, UsarSello);
        }
    }
}
