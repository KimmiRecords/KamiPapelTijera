using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbuelaDialogueTrigger : TriggerDialogue
{
    bool firstTime = true;


    protected override void Start()
    {
        print("me suscribo a onplayerpressed E y abueladropoff - awela");

        EventManager.Subscribe(Evento.OnPlayerPressedE, Interact); //los triggers siempre estan atentos a que el player aprete E
        EventManager.Subscribe(Evento.OnAbuelaDropoff, PasarAlSiguienteDialogo);
    }

    public override void Interact(params object[] parameter)
    {
        //if (firstTime)
        //{
        //    if (triggerBool)
        //    {
        //        //print("trigger dialogue interact: muestro el dialogo " + _dialogues[currentDialogue].name);
        //        DialogueManager.instance.ShowDialogue(_dialogues[currentDialogue]);
        //    }

        //    if (_burnAfterReading)
        //    {
        //        Destroy(this);
        //    }

        //    firstTime = false;
        //}

        if (triggerBool)
        {
            DialogueManager.instance.ShowDialogue(_dialogues[currentDialogue]);
            if (firstTime)
            {
                firstTime = false;
                AudioManager.instance.PlayByName("MagicSuccess", 4.0f);
                PasarAlSiguienteDialogo(); //despues de hablarle x primera vez a la awela, pasa al dialogo 1bis
            }
        }
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
