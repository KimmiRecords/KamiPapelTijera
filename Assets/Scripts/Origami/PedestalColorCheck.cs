using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalColorCheck : MonoBehaviour
{
    public Color inactiveColor;
    public Color activeColor;

    public TriggerOrigami myTriggerOrigami;
    Renderer _renderer;

    private void Start()
    {
        EventManager.Subscribe(Evento.OnResourceUpdated, SetPedestalColor);
        _renderer = GetComponent<Renderer>();

        _renderer.material.color = inactiveColor;
        SetPedestalColor(ResourceType.papel);
    }

    public void SetPedestalColor(params object[] parameter)
    {
        //cuando el player gana algun recurso, chequea si era papel, y si tengo sufi, lo activo
        if ((ResourceType)parameter[0] == ResourceType.papel)
        {
            if (LevelManager.Instance.recursosRecolectados[ResourceType.papel] >= myTriggerOrigami.origami.paperCost)
            {
                //print("tengo suficiente papel para hacer este origami");
                _renderer.material.color = activeColor;
            }
            else
            {
                //print("no tengo suficiente papel para hacer este origami");
                _renderer.material.color = inactiveColor;
            }
        }

        if (myTriggerOrigami.origami.wasUsed)
        {
            _renderer.material.color = inactiveColor;
        }
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnResourceUpdated, SetPedestalColor);
        }
    }
}
