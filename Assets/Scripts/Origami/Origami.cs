using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum OrigamiStance
{
    Grulla,
    Barco
}

public class Origami : MonoBehaviour
{
    public OrigamiStance origamiStance;
    public Image origamiRouteImage;
    public RectTransform puntoInicio;
    public RectTransform puntoFinal;

    public void Apply()
    {
        EventManager.Trigger(Evento.OnOrigamiApplied, origamiStance);
        print("onorigamiapplied triggereado");
    }
}
