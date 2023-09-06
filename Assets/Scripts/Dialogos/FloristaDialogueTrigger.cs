using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloristaDialogueTrigger : TriggerDialogue
{
    [SerializeField] int _paperReward = 20;
    [SerializeField] QuestSO _quest; //la quest que da este pj

    bool _questCompleted;
    bool _questDelivered;

    protected override void Start()
    {
        EventManager.Subscribe(Evento.OnPlayerPressedE, Interact); //los triggers siempre estan atentos a que el player aprete E
        EventManager.Subscribe(Evento.OnQuestCompleted, CompletarQuest);
        //EventManager.Subscribe(Evento.OnDialogueEnd, PasarAlSiguienteDialogo);
    }

    //dialogos: 
    //el 0 es pedir la quest (first time)
    //el 1 es el fijo mientras la quest esta prendida
    //el 2 es el de gracias por traerme las flores con reward (first time)
    //el 3 es el fijo despues de haber completado la quest

    public override void Interact(params object[] parameter)
    {
        if (triggerBool) //este temita del interact se podria hacer mejor, ya lo demostre en otro lado
        {
            //Debug.Log("dalia: me interactuan");

            if (_questCompleted && !_questDelivered)
            {
                Debug.Log("dalia: quest entregada!");
                QuestManager.Instance.RemoveQuest(_quest);
                LevelManager.Instance.AddResource(_quest.conditions[0].resourceType, -_quest.conditions[0].requiredAmount); //esto deberia funcar foreach condition
                LevelManager.Instance.AddResource(ResourceType.papel, _paperReward);
                AudioManager.instance.PlayByName("QuestCompleted02");
                currentDialogue = 2;
                _questDelivered = true;

            }

            Debug.Log("dalia: muestro currentdialogue");
            DialogueManager.Instance.ShowDialogue(_dialogues[currentDialogue]);

            switch (currentDialogue)
            {
                case 0:
                    QuestManager.Instance.AddQuest(_quest);
                    currentDialogue++;
                    break;

                case 1:
                    break;

                case 2:
                    currentDialogue++;
                    break;

                case 3:
                    break;

            }
        }

        if (_burnAfterReading)
        {
            Destroy(this);
        }
    }
    protected void CompletarQuest(params object[] parameter)
    {
        Debug.Log("dalia: completar quest");
        if ((QuestSO)parameter[0] == _quest) //si la quest que se completo es la mia
        {
            Debug.Log("dalia: me entero que se completo la quest");
            _questCompleted = true;
        }
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
            EventManager.Unsubscribe(Evento.OnQuestCompleted, CompletarQuest);
            //EventManager.Unsubscribe(Evento.OnDialogueEnd, PasarAlSiguienteDialogo);
        }
    }
}
