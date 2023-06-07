using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleRectCheck : MonoBehaviour
{
    //este multiple rectangle check solo nace cuando estas dentro de un sello (por ahora origami)
    //asi corre el update pero solo cuando lo necesitamos
    //aca esta la mecanica de arrastrar el mouse y eso

    Origami desiredOrigami;

    bool invocando = false;
    bool arrastrando = false;
    bool wasUsed;
    Origami currentOrigami;
    int paperCost; //numero negativo si o si

    public MultipleRectCheck SetOrigami(Origami ori, int cost, bool fueUsado)
    {
        desiredOrigami = ori;
        paperCost = cost;
        wasUsed = fueUsado;

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
            //print("invocacion cancelada x soltar tab");
        }

        if (invocando && Input.GetMouseButtonDown(1))
        {
            //chequeo si el mouse esta dentro de la imagen roja, y habilito el arranque
            if (RectTransformUtility.RectangleContainsScreenPoint(currentOrigami.inicioRectangle, Input.mousePosition))
            {
                arrastrando = true;
                AudioManager.instance.PlayRandom("PaperFold01", "PaperFold02");
                AudioManager.instance.PlayByName("PaperFoldLoop");

            }
            else
            {
                Debug.Log("invocación cancelada x empezar en un lugar incorrecto");
                EndOrigami(currentOrigami);
            }
        }

        //chequeo si el jugador solto el mouse mientras arrastraba
        if (arrastrando && Input.GetMouseButtonUp(1))
        {
            //chequeo si el jugador solto sobre la imagen verde
            if (RectTransformUtility.RectangleContainsScreenPoint(currentOrigami.finalRectangle, Input.mousePosition))
            {
                //Debug.Log("invocación exitosa");
                AudioManager.instance.PlayRandom("PaperFold01", "PaperFold02");
                ApplyOrigami(currentOrigami);
                EndOrigami(currentOrigami);
            }
            else
            {
                //Debug.Log("invocación cancelada x soltar mal");
                AudioManager.instance.PlayByNameRandomPitch("MagicFail", 1, 0.05f);
                EndOrigami(currentOrigami);
            }

            arrastrando = false;
        }


        bool encimaDeAlgunRectangulo = false;

        foreach (RectTransform rectTransform in desiredOrigami.routeRectangles) //chequeo si estoy encima de algun rectangulo
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition))
            {
                encimaDeAlgunRectangulo = true; //si sí, todo bien
                break;
            }
        }
        if (arrastrando && !encimaDeAlgunRectangulo) //si no, end origami
        {
            // Me salí de la ruta
            arrastrando = false;
            AudioManager.instance.PlayByNameRandomPitch("MagicFail", 1, 0.05f);
            Debug.Log("invocación cancelada x salir de la ruta");
            EndOrigami(currentOrigami);
        }

    }

    public void StartOrigami(Origami origami)
    {
        if (!wasUsed)
        {
            //print("arranca la invocacion");
            currentOrigami = origami;
            origami.gameObject.SetActive(true);
            invocando = true;
            TooltipManager.instance.ShowTooltip(origami.tooltipMessage, origami.postItColor);
            AudioManager.instance.PlayRandom("MagicChannelingLoop01", "MagicChannelingLoop02");
        }

    }

    public void EndOrigami(Origami origami)
    {
        invocando = false;
        arrastrando = false;
        origami.gameObject.SetActive(false);
        //print("invocacion cancelada");
        TooltipManager.instance.HideTooltip();
        AudioManager.instance.StopByName("PaperFoldLoop");
        AudioManager.instance.StopByName("MagicChannelingLoop01", "MagicChannelingLoop02");
    }

    public void ApplyOrigami(Origami origami)
    {
        EventManager.Trigger(Evento.OnOrigamiApplied, -paperCost, origami);
        origami.Apply(); //aca esta la papa. cada origami se fija que tiene que hacer
        wasUsed = true;
        //print("origami aplicado");
    }
}
