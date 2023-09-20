using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranjeroNorbertoDialogueTrigger : QuestDialogueTrigger
{
    [SerializeField] GameObject tijeraPickup;

    protected override void ShowFirstTimeDialogue()
    {
        tijeraPickup.SetActive(true);
        base.ShowFirstTimeDialogue();
    }

    protected override void DeliverQuest()
    {
        //Debug.Log("dalia: quest entregada!");
        QuestManager.Instance.RemoveQuest(_quest);
        AudioManager.instance.PlayByName("QuestCompleted02", 1.1f);
        currentDialogue = 2;
        _questDelivered = true;
        EventManager.Trigger(Evento.OnQuestDelivered, _quest);
    }

    protected override void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerPressedE, Interact);
            EventManager.Unsubscribe(Evento.OnAbuelaDropoff, CompleteQuest);
        }
    }

}
