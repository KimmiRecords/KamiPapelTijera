using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum OrigamiForm
{
    Grulla,
    Barco,
    Puente
}

public abstract class Origami : MonoBehaviour
{
    public OrigamiForm origamiForm;

    public OrigamiRoute[] origamiRoutes;
    public int paperCost;

    public string tooltipMessage;
    public PostItColor postItColor;

    [HideInInspector]
    public int currentRouteIndex = 0;

    [HideInInspector]
    public bool wasUsed;

    public void FailOrigami()
    {
        //print("fallaste asi que arrancas de cero");
        currentRouteIndex = 0;

        for (int i = 0; i < origamiRoutes.Length; i++)
        {
            origamiRoutes[i].wasCompleted = false;
            if (currentRouteIndex == i)
            {
                origamiRoutes[i].gameObject.SetActive(true);
            }
            else
            {
                origamiRoutes[i].gameObject.SetActive(false);
            }
        }
    }

    public virtual void NextRoute() //prendo la ruta index, apago las demas
    {
        for (int i = 0; i < origamiRoutes.Length; i++)
        {
            if (currentRouteIndex == i)
            {
                origamiRoutes[i].gameObject.SetActive(true);
            }
            else
            {
                origamiRoutes[i].gameObject.SetActive(false);
            }
        }
        TriggerPliegueTextUpdater();
    }

    public virtual void CompleteRoute()
    {
        print("ruta actual completada");
        origamiRoutes[currentRouteIndex].wasCompleted = true;
        currentRouteIndex++;

        if (currentRouteIndex >= origamiRoutes.Length)
        {
            print("completaste el origami");
            currentRouteIndex = 0;
            wasUsed = true;
            Apply();
        }
        else
        {
            print("siguienteee");
            NextRoute();
        }
    }

    public virtual void Apply()
    {
        print("origami apply");
        //EventManager.Trigger(Evento.OnOrigamiApplied, -paperCost, this);

        //consume papel
        LevelManager.instance.AddResource(ResourceType.papel, -paperCost);
    }

    public void TriggerPliegueTextUpdater()
    {
        print("triggereo con " + (currentRouteIndex + 1).ToString() + "/" + origamiRoutes.Length);
        EventManager.Trigger(Evento.OnOrigamiFoldChange, currentRouteIndex + 1, origamiRoutes.Length);
    }

}
