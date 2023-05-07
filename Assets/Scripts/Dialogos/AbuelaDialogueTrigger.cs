using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbuelaDialogueTrigger : TriggerDialogue
{
    protected override void Start()
    {
        print("me suscribo a onplayerpressed E y abueladropoff - granjero norberto");

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
