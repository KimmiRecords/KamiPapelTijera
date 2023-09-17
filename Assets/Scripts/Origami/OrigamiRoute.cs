using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigamiRoute : MonoBehaviour
{
    public RectTransform inicioRectangle;
    public List<RectTransform> routeRectangles;
    public RectTransform finalRectangle;

    [HideInInspector] public bool wasCompleted;
    [SerializeField] float interpolation = 0;
    [SerializeField] Vector3 distanciaMouseInicio;
    [SerializeField] Vector3 distanciaTotal;
    [SerializeField] Vector3 posicionInicioOriginal;
    bool originalPositionWasSet = false;

    private void Start()
    {
        //print("agregue los rectangulos inicio y fin a la lista");
        routeRectangles.Add(inicioRectangle);
        routeRectangles.Add(finalRectangle);

        posicionInicioOriginal = inicioRectangle.position;
        originalPositionWasSet = true;
        distanciaTotal = finalRectangle.position - inicioRectangle.position;
    }

    public void SetImagePosition(Vector3 mousePosition)
    {
        //Debug.Log("SET IMAGE POSITION calculo posicion de la imagen inicio");
        distanciaMouseInicio = mousePosition - posicionInicioOriginal;
        interpolation = distanciaMouseInicio.magnitude / distanciaTotal.magnitude;
        inicioRectangle.position = Vector3.Lerp(posicionInicioOriginal, finalRectangle.position, interpolation);
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
