using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrigamiRoute : MonoBehaviour
{
    public RectTransform startingPoint;
    public RectTransform inicioRectangle; //flechaverde
    public List<RectTransform> routeRectangles; //el camino
    public RectTransform finalRectangle; //flecharoja

    [HideInInspector] public bool wasCompleted;
    float interpolation = 0;
    Vector3 distanciaMouseInicio;
    Vector3 distanciaTotal;
    Vector3 posicionInicioOriginal;
    bool originalPositionWasSet = false;

    [SerializeField] Animator _flipbookAnimator;

    private void Start()
    {
        //print("agregue los rectangulos inicio y fin a la lista");
        //routeRectangles.Add(inicioRectangle);
        routeRectangles.Add(finalRectangle);

        posicionInicioOriginal = startingPoint.position;
        originalPositionWasSet = true;
        distanciaTotal = finalRectangle.position - startingPoint.position;

    }

    public void SetOrigamiSliderValue(float value)
    {
        _flipbookAnimator.SetFloat("_OrigamiSlider", value); //seteo el valor del slider del material
    }

    public void SetImagePosition(Vector3 mousePosition)
    {
        //Debug.Log("SET IMAGE POSITION calculo posicion de la imagen inicio");
        //tiene el bug de que no me sirve para rutas no rectas
        distanciaMouseInicio = mousePosition - posicionInicioOriginal;

        interpolation = distanciaMouseInicio.magnitude / distanciaTotal.magnitude;

        inicioRectangle.position = Vector3.Lerp(posicionInicioOriginal, finalRectangle.position, interpolation);
        SetOrigamiSliderValue(interpolation);
    }

    public void ResetImagePosition()
    {
        if (originalPositionWasSet)
        {
            //Debug.Log("RESET IMAGE POSITION");
            inicioRectangle.position = posicionInicioOriginal;
        }
    }
}
