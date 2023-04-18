using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSolapa : TriggerScript
{
    [SerializeField]
    Solapa solapaAfectada;

    [SerializeField]
    GameObject objetoParaMostrar;

    [SerializeField]
    float tiempoHastaMostrarObjeto;

    bool isShowing;

    public override void Interact(params object[] parameter)
    {
        if (triggerBool)
        {
            solapaAfectada.CambiarEstado();
            StartCoroutine(ToggleObject(objetoParaMostrar));
        }
    }

    public IEnumerator ToggleObject(GameObject objeto)
    {
        yield return new WaitForSeconds(tiempoHastaMostrarObjeto);

        if (isShowing)
        {
            objeto.SetActive(false);
        }
        else
        {
            objeto.SetActive(true);
        }
        isShowing = !isShowing;
    }
}
