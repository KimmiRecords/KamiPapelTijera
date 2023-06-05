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
    public Image origamiRouteImage;
    public RectTransform puntoInicio;
    public RectTransform puntoFinal;

    public string tooltipMessage;
    public PostItColor postItColor;

    public virtual void Apply()
    {
        print("onorigamiapplied triggereado");
    }

}
