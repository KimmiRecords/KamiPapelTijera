using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDialogueTrigger : TriggerDialogue
{
    //si tu npc tiene exactamente 4 dialogos y una quest de recursos:
    //este script es para vos
    

    [SerializeField] int _paperReward = 20;
    [SerializeField] QuestSO _quest; //la quest que da este pj
    bool _questCompleted;
    bool _questDelivered;
    bool firstTime = true;

    protected override void Start()
    {
        EventManager.Subscribe(Evento.OnPlayerPressedE, Interact); //los triggers siempre estan atentos a que el player aprete E
        EventManager.Subscribe(Evento.OnQuestCompleted, CompleteQuest);
        //EventManager.Subscribe(Evento.OnDialogueEnd, PasarAlSiguienteDialogo);
    }

    //dialogos: 
    //el 0 es pedir la quest (first time)
    //el 1 es el fijo mientras la quest esta prendida
    //el 2 es el de gracias por traerme las flores con reward (first time)
    //el 3 es el fijo despues de haber completado la quest

    public override void Interact(params object[] parameter)
    {
        if (triggerBool && !LevelManager.Instance.inDialogue) //este temita del interact se podria hacer mejor, ya lo demostre en otro lado
        {

            if (firstTime)
            {
                //mostrar el 0 si o si, y pasar al 1
                DialogueManager.Instance.ShowDialogue(_dialogues[0]);
                QuestManager.Instance.AddQuest(_quest);
                currentDialogue++;
                firstTime = false;
                return;
            }

            if (_questCompleted && !_questDelivered)
            {
                DeliverQuest();
            }

            DialogueManager.Instance.ShowDialogue(_dialogues[currentDialogue]);

            if (currentDialogue == 2) //el 2 es el unico q pasa automatico al 3
            {
                currentDialogue++;
            }
        }

        if (_burnAfterReading)
        {
            Destroy(this);
        }
    }
    protected void CompleteQuest(params object[] parameter)
    {
        Debug.Log("dalia: completar quest");
        if ((QuestSO)parameter[0] == _quest) //si la quest que se completo es la mia
        {
            Debug.Log("dalia: me entero que se completo la quest");
            _questCompleted = true;
        }
    }

    protected void DeliverQuest()
    {
        //Debug.Log("dalia: quest entregada!");
        QuestManager.Instance.RemoveQuest(_quest);
        LevelManager.Instance.AddResource(_quest.condition.resourceType, -_quest.condition.requiredAmount); //esto deberia funcar para condition evento. tal vez con una interfaz IQuestCondition con metodo complete/deliver
        LevelManager.Instance.AddResource(ResourceType.papel, _paperReward);
        AudioManager.instance.PlayByName("QuestCompleted02");
        currentDialogue = 2;
        _questDelivered = true;
        EventManager.Trigger(Evento.OnQuestDelivered, _quest);
    }

    //protected override void PasarAlSiguienteDialogo(params object[] parameter)
    //{
    //    if ((Dialogue)parameter[1] == _dialogues[0])
    //    {
    //        //solo me interesa si el dialogo que terminó fue el 0
    //        base.PasarAlSiguienteDialogo(parameter);
    //    }
    //}

    protected override void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerPressedE, Interact);
            EventManager.Unsubscribe(Evento.OnQuestCompleted, CompleteQuest);
            //EventManager.Unsubscribe(Evento.OnDialogueEnd, PasarAlSiguienteDialogo);
        }
    }
}
