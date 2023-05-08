using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranjeroNorbertoDialogueTrigger : TriggerDialogue
{
    protected override void Start()
    {
        EventManager.Subscribe(Evento.OnPlayerPressedE, Interact); //los triggers siempre estan atentos a que el player aprete E
        EventManager.Subscribe(Evento.OnAbuelaDropoff, PasarAlSiguienteDialogo);
    }

    protected override void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerPressedE, Interact);
            EventManager.Unsubscribe(Evento.OnAbuelaDropoff, PasarAlSiguienteDialogo);
        }
    }

}
