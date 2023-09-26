using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbuelaDialogueTrigger : TriggerDialogue
{
    //este script maneja todo lo que es dialogos de la abuela
    //nada que ver con los movimientos. eso esta en el npc_abuela

    //la abuela tiene 2 dialogos. 
    //cuando te la encontras (que dispara la bossfight)
    //y el post-entrega (que dispara el final)

    bool firstTime = true;
    [SerializeField] NPC_Abuela abuela;
    bool isLocked = false;

    protected override void Start()
    {
        //print("me suscribo a onplayerpressed E y abueladropoff - awela");
        EventManager.Subscribe(Evento.OnPlayerPressedE, Interact); //los triggers siempre estan atentos a que el player aprete E
        EventManager.Subscribe(Evento.OnAbuelaDropoff, Unlock);
        EventManager.Subscribe(Evento.OnDialogueEnd, EndAllInteractions);
        EventManager.Subscribe(Evento.OnPlayerChooseContinueGame, Unlock);
    }

    public void EndAllInteractions(params object[] parameters)
    {
        //si el dialogo q termino es el ultimo de la abuela
        if ((DialogueSO)parameters[1] == _dialogues[1])
        {
            Debug.Log("listo, se acabo todo. chau.");
            isLocked = true;   
        }
    }

    void Unlock(object[] parameters)
    {
        isLocked = false;
    }

    public override void OnEnterBehaviour(Collider other)
    {
        triggerBool = true;
        if (!isLocked)
        {
            TooltipManager.Instance.ShowTooltip(tooltipTextToShow, postItColor);
        }
    }

    public override void Interact(params object[] parameter)
    {
        //solo se puede interactuar con la abuela cuando ella esa quieta. 
        //mientras te sigue, no podes hablarle

        if (isLocked)
        {
            return;
        }

        if (triggerBool)
        {
            DialogueManager.Instance.ShowDialogue(_dialogues[currentDialogue]);

            if (firstTime)
            {
                firstTime = false;
                isLocked = true; //la lockeo para q no te hable mas hasta ser deslockeada
                AudioManager.instance.PlayByName("MagicSuccess", 4.0f);
                PasarAlSiguienteDialogo(); //despues de hablarle x primera vez a la awela, pasa al dialogo 2
            }
        }
    }

    protected override void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerPressedE, Interact);
            EventManager.Unsubscribe(Evento.OnAbuelaDropoff, Unlock);
            EventManager.Unsubscribe(Evento.OnDialogueEnd, EndAllInteractions);
            EventManager.Unsubscribe(Evento.OnPlayerChooseContinueGame, Unlock);
        }
    }
}
