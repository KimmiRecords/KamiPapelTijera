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


    //BUENO, NO REALMENTE
    //la abuela va a tener 3 dialogos
    //1. cuando la encontras -> habilita la bossfight
    //2. post-boss -> habilita el origami
    //3. post-entrega y post-norberto -> habilita el final storyboard


    bool firstTime = true;
    [SerializeField] NPC_Abuela abuela;
    bool isLocked = false;

    [SerializeField] GameObject globitoDialogo;
    [SerializeField] QuestSO requiredQuest; //la quest necesaria para desbloquear el segundo dialogo
    [SerializeField] GameObject foldOrigamiSeal, unfoldOrigamiSeal;
    Origami foldOrigami, unfoldOrigami;

    protected override void Start()
    {
        EventManager.Subscribe(Evento.OnPlayerPressedE, Interact); //los triggers siempre estan atentos a que el player aprete E
        EventManager.Subscribe(Evento.OnDialogueEnd, OnDialogueEnded);
        EventManager.Subscribe(Evento.OnPlayerChooseContinueGame, Unlock);
        EventManager.Subscribe(Evento.OnQuestDelivered, CheckQuestCompletion);
        EventManager.Subscribe(Evento.OnEncounterEnd, Unlock);

        foldOrigami = foldOrigamiSeal.GetComponentInChildren<TriggerOrigami>().origami;
        unfoldOrigami = unfoldOrigamiSeal.GetComponentInChildren<TriggerOrigami>().origami;

    }

    public void OnDialogueEnded(params object[] parameters)
    {
        Debug.Log("on dialogue ended");

        if ((DialogueSO)parameters[1] == _dialogues[0])
        {
            OnFirstDialogueEnded();
        }

        if ((DialogueSO)parameters[1] == _dialogues[1])
        {
            OnSecondDialogueEnded();
        }

        if ((DialogueSO)parameters[1] == _dialogues[2])
        {
            OnThirdDialogueEnded();
        }
    }

    public void OnOrigamiEnded(params object[] parameters)
    {
        Debug.Log("on origami ended");

        if ((Origami)parameters[0] == foldOrigami)
        {
            Debug.Log("on origami ended - fold origami");
            EnableOrigamiSeal(foldOrigamiSeal, false);

            //termine de doblar a la abuela
            //avisar al inventario que agregue a la abuela
            //hacer desaparecer a la abuela de la escena
            //sonidito y particulas
            //mostrar el icono de la abuela durante unos segundos
        }

        if ((Origami)parameters[0] == unfoldOrigami)
        {
            Debug.Log("on origami ended - unfold origami");

            EnableOrigamiSeal(unfoldOrigamiSeal, false);

            //termine de desdoblar a la abuela
            //avisar al inventario que saque a la abuela
            //hacer aparecer a la abuela en la escena
            //sonidito y particulas

            Unlock();
        }
    }

    void CheckQuestCompletion(params object[] parameters)
    {
        //si la quest que se completó es la required...
        if ((QuestSO)parameters[0] == requiredQuest)
        {
            Debug.Log("required quest completed");

            //ubicar a la abuela next to kami
            EnableOrigamiSeal(unfoldOrigamiSeal, true);
            Unlock();
        }
    }

    void Unlock(params object[] parameters)
    {
        //habilita poder hablarle a la abuela
        isLocked = false;
        globitoDialogo.SetActive(true);
    }
    public void Lock()
    {
        isLocked = true; //la lockeo para q no puedas hablarle hasta ser deslockeada
        globitoDialogo.SetActive(false);
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
        if (isLocked)
        {
            return;
        }

        if (triggerBool)
        {
            DialogueManager.Instance.ShowDialogue(_dialogues[currentDialogue]);

            if (firstTime)
            {
                OnFirstDialogueEnded();
            }
        }
    }

    public void OnFirstDialogueEnded()
    {
        Debug.Log("on first dialogue ended");

        firstTime = false;
        AudioManager.instance.PlayByName("MagicSuccess", 2f);
        Lock();
        PasarAlSiguienteDialogo(); //despues de hablarle x primera vez a la awela, pasa al dialogo 2
    }

    public void OnSecondDialogueEnded()
    {
        Debug.Log("on second dialogue ended");
        EnableOrigamiSeal(foldOrigamiSeal, true);
        Lock();
        PasarAlSiguienteDialogo();
    }

    public void OnThirdDialogueEnded()
    {
        Debug.Log("on third dialogue ended");
        isLocked = true;
    }

    public void EnableOrigamiSeal(GameObject origamiSeal, bool value)
    {
        Debug.Log("enable origami seal" + origamiSeal + value);
        origamiSeal.SetActive(value);
    }

    protected override void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerPressedE, Interact);
            EventManager.Unsubscribe(Evento.OnDialogueEnd, OnDialogueEnded);
            EventManager.Unsubscribe(Evento.OnPlayerChooseContinueGame, Unlock);
            EventManager.Unsubscribe(Evento.OnQuestDelivered, CheckQuestCompletion);
            EventManager.Unsubscribe(Evento.OnEncounterEnd, Unlock);
        }
    }
}
