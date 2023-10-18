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
    //y el post-entrega (que dispara el final storyboard)

    //el segundo dialogo recien se desbloquea cuando entregas la quest de norberto

    bool firstTime = true;
    [SerializeField] NPC_Abuela abuela;
    bool isLocked = false;

    [SerializeField] GameObject globitoDialogo;
    [SerializeField] QuestSO requiredQuest; //la quest necesaria para desbloquear el segundo dialogo

    protected override void Start()
    {
        //print("me suscribo a onplayerpressed E y abueladropoff - awela");
        EventManager.Subscribe(Evento.OnPlayerPressedE, Interact); //los triggers siempre estan atentos a que el player aprete E
        //EventManager.Subscribe(Evento.OnAbuelaDropoff, Unlock);
        EventManager.Subscribe(Evento.OnDialogueEnd, EndAllInteractions);
        EventManager.Subscribe(Evento.OnPlayerChooseContinueGame, Unlock);
        EventManager.Subscribe(Evento.OnQuestDelivered, CheckQuestCompletion);

    }

    public void EndAllInteractions(params object[] parameters)
    {
        //si el dialogo q termino es el ultimo de la abuela
        if ((DialogueSO)parameters[1] == _dialogues[1])
        {
            //Debug.Log("listo, se acabo todo. chau.");
            isLocked = true;
            //igual este lock se unlockea si el player elige continue game
        }
    }
    void CheckQuestCompletion(params object[] parameters)
    {
        if ((QuestSO)parameters[0] == requiredQuest)
        {
            Unlock();
        }
    }

    void Unlock(params object[] parameters)
    {
        isLocked = false;
        globitoDialogo.SetActive(true);
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
                globitoDialogo.SetActive(false);
                AudioManager.instance.PlayByName("MagicSuccess", 2f);
                PasarAlSiguienteDialogo(); //despues de hablarle x primera vez a la awela, pasa al dialogo 2
            }
        }
    }

    protected override void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerPressedE, Interact);
            //EventManager.Unsubscribe(Evento.OnAbuelaDropoff, Unlock);
            EventManager.Unsubscribe(Evento.OnDialogueEnd, EndAllInteractions);
            EventManager.Unsubscribe(Evento.OnPlayerChooseContinueGame, Unlock);
            EventManager.Unsubscribe(Evento.OnQuestDelivered, CheckQuestCompletion);

        }
    }
}
