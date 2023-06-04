using UnityEngine;
using UnityEngine.UI;


public class Invocacion : MonoBehaviour
{
    public Origami grulla;
    public Origami barco;

    bool invocando = false;
    bool arrastrando = false;

    Origami currentOrigami;

    void Update()
    {
        // Iniciar la invocación cuando se presiona la tecla Z
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartOrigami(grulla);
        }
        // Cancelar la invocación si se suelta la tecla Z
        if (Input.GetKeyUp(KeyCode.Z))
        {
            EndOrigami(grulla);
            print("invocacion cancelada x soltar la Z");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            StartOrigami(barco);
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            EndOrigami(barco);
            print("invocacion cancelada x soltar la X");
        }

        if (invocando && Input.GetMouseButtonDown(1))
        {
            // Comprobar si el mouse está dentro de la imagen del canvas
            if (RectTransformUtility.RectangleContainsScreenPoint(currentOrigami.puntoInicio, Input.mousePosition))
            {
                arrastrando = true;
            }
        }

        // Comprobar si el jugador ha soltado el mouse
        if (arrastrando && Input.GetMouseButtonUp(1))
        {
            // Comprobar si el mouse está dentro de la imagen del canvas
            if (RectTransformUtility.RectangleContainsScreenPoint(currentOrigami.origamiRouteImage.rectTransform, Input.mousePosition))
            {
                // Comprobar si el jugador ha arrastrado desde el punto de inicio al punto final
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
        origami.origamiRouteImage.gameObject.SetActive(true);
        print("arranca la invocacion");
    }

    public void EndOrigami(Origami origami)
    {
        invocando = false;
        arrastrando = false;
        origami.origamiRouteImage.gameObject.SetActive(false);
        //print("invocacion cancelada");
    }

    public void ApplyOrigami(Origami origami)
    {
        origami.Apply();
        print("origami aplicado");
    }
}


