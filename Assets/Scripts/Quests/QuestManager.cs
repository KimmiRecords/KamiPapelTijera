using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public enum RewardType
{
    SprintBoots,
    WaterBoots,
    None,
    Count
}


public class QuestManager : Singleton<QuestManager>
{
    List<QuestSO> quests = new List<QuestSO>();
    Dictionary<Evento, bool> eventosSucedidos = new Dictionary<Evento, bool>();

    void Start()
    {
        EventManager.Subscribe(Evento.OnResourceUpdated, CheckQuests);
        EventManager.Subscribe(Evento.OnAbuelaDropoff, SetAbuelaDropoff); //deberia ser generico
        EventManager.Subscribe(Evento.OnQuestDelivered, GiveReward);
    }

    private void GiveReward(params object[] parameters)
    {
        QuestSO deliveredQuest = (QuestSO)parameters[0];

        switch (deliveredQuest.rewardType)
        {
            case RewardType.SprintBoots:
                LevelManager.Instance.GiveSprintBoots();
                break;
            case RewardType.WaterBoots:
                LevelManager.Instance.GiveWaterBoots();
                break;
            case RewardType.None:
                break;
            case RewardType.Count:
                break;
            default:
                break;
        }
    }

    public void SetAbuelaDropoff(params object[] parameter)
    {
        eventosSucedidos[Evento.OnAbuelaDropoff] = true;
        CheckQuests();
    }
    public void CheckQuests(params object[] parameters)
    {
        //Debug.Log("me pongo a chequear todas las quests");
        foreach (QuestSO quest in quests)
        {
            if (quest.condition.conditionType == ConditionType.Resource &&
                LevelManager.Instance.recursosRecolectados[quest.condition.resourceType] >= quest.condition.requiredAmount)
            {
                //Debug.Log("quest manager: se completo la " + quest.name);
                CompleteQuest(quest);
            }

            if (quest.condition.conditionType == ConditionType.Event &&
                eventosSucedidos[quest.condition.evento])
            {
                Debug.Log("quest manager: se completo la " + quest.name);
                CompleteQuest(quest);
            }
        }
    }
    public void AddQuest(QuestSO quest) //esto lo disparan los npcs cuando les hablo
    {
        //Debug.Log("agrego la quest");
        quests.Add(quest);
        CheckQuests();

        //if (quest.condition.conditionType == ConditionType.Event)
        //{
        //    eventosSucedidos.Add(quest.condition.evento, false);
        //    EventManager.Subscribe(quest.condition.evento, SetAbuelaDropoff); //deberia ser generico
        //}
    }
    public void RemoveQuest(QuestSO quest)
    {
        Debug.Log("remuevo la quest");
        quests.Remove(quest);
    }
    public void CompleteQuest(QuestSO quest)
    {
        EventManager.Trigger(Evento.OnQuestCompleted, quest);
        Debug.Log("complete la quest");
    }

    void OnDestroy()
    {
        if(!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnResourceUpdated, CheckQuests);
            EventManager.Unsubscribe(Evento.OnQuestDelivered, GiveReward);
        }
    }
}
