using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigamiCheck : MonoBehaviour
{
    //la cosa es que el origami solo funca bien si lo codeo en el update. 
    //este origamicheck solo nace cuando estas dentro del sello de origami
    //asi corre el update pero solo cuando lo necesitamos

    Origami desiredOrigami;

    bool invocando = false;
    bool arrastrando = false;
    Origami currentOrigami;

    public OrigamiCheck SetOrigami(Origami ori)
    {
        desiredOrigami = ori;
        return this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            StartOrigami(desiredOrigami);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            EndOrigami(desiredOrigami);
            print("invocacion cancelada x soltar tab");
        }

        if (invocando && Input.GetMouseButtonDown(1))
        {
            //chequeo si el mouse esta dentro de la imagen roja
            if (RectTransformUtility.RectangleContainsScreenPoint(currentOrigami.puntoInicio, Input.mousePosition))
            {
                arrastrando = true;
            }
        }

        //chequeo si el jugador solto el mouse mientras arrastraba
        if (arrastrando && Input.GetMouseButtonUp(1))
        {
            //y si esta dentro de la ruta
            if (RectTransformUtility.RectangleContainsScreenPoint(currentOrigami.origamiRouteImage.rectTransform, Input.mousePosition))
            {
                //chequeo si el jugador solto sobre la imagen verde
                bool invocacionExitosa = RectTransformUtility.RectangleContainsScreenPoint(currentOrigami.puntoFinal, Input.mousePosition);

                if (invocacionExitosa)
                {
                    Debug.Log("¡Invocación exitosa!");
                    ApplyOrigami(currentOrigami);
                    EndOrigami(currentOrigami);
                }
                else
                {
                    Debug.Log("¡Invocación cancelada x soltar en lugar incorrecto!");
                    EndOrigami(currentOrigami);
                }
            }
            else
            {
                Debug.Log("¡Invocación cancelada x soltar fuera de la ruta!");
                EndOrigami(currentOrigami);
            }

            arrastrando = false;
        }

        if (arrastrando && !RectTransformUtility.RectangleContainsScreenPoint(currentOrigami.origamiRouteImage.rectTransform, Input.mousePosition))
        {
            //me sali de la ruta
            arrastrando = false;
            Debug.Log("¡Invocación cancelada x salir de la ruta!");
            EndOrigami(currentOrigami);
        }
    }

    public void StartOrigami(Origami origami)
    {
        invocando = true;
        currentOrigami = origami;
        origami.gameObject.SetActive(true);
        print("arranca la invocacion");
    }

    public void EndOrigami(Origami origami)
    {
        invocando = false;
        arrastrando = false;
        origami.gameObject.SetActive(false);
        //print("invocacion cancelada");
    }

    public void ApplyOrigami(Origami origami)
    {
        origami.Apply();
        print("origami aplicado");
    }
}
