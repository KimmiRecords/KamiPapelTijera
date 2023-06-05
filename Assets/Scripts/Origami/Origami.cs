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

public class Origami : MonoBehaviour
{
    public OrigamiForm origamiForm;
    public Image origamiRouteImage;
    public RectTransform puntoInicio;
    public RectTransform puntoFinal;

    public virtual void Apply()
    {
        EventManager.Trigger(Evento.OnOrigamiApplied, origamiForm);
        print("onorigamiapplied triggereado");
    }

}
