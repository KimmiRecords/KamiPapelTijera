using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranjeroNorbertoDialogueTrigger : TriggerDialogue
{
    bool firstTime = true;

    [SerializeField] GameObject tijeraPickup, triggerText;


    protected override void Start()
    {
        EventManager.Subscribe(Evento.OnPlayerPressedE, Interact); //los triggers siempre estan atentos a que el player aprete E
        EventManager.Subscribe(Evento.OnAbuelaDropoff, PasarAlSiguienteDialogo);
    }

    public override void Interact(params object[] parameter)
    {
        if (triggerBool)
        {
            DialogueManager.instance.ShowDialogue(_dialogues[currentDialogue]);
            if (firstTime)
            {
                tijeraPickup.SetActive(true);
                triggerText.SetActive(true);

                firstTime = false;
                AudioManager.instance.PlayByName("MagicSuccess", 4.0f);
            }
        }

        if (_burnAfterReading)
        {
            Destroy(this);
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
