using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    public List<QuestSO> quests = new List<QuestSO>();

    void Start()
    {
        EventManager.Subscribe(Evento.OnResourceUpdated, CheckQuests);
    }

    public void CheckQuests(params object[] parameters)
    {
        Debug.Log("me pongo a chequear todas las quests");
        foreach (QuestSO quest in quests)
        {
            foreach (Condition condition in quest.conditions)
            {
                if (condition.requiredAmount >= LevelManager.Instance.recursosRecolectados[condition.resourceType])
                {
                    Debug.Log("quest manager: se completo la " + quest.name);
                    CompleteQuest(quest);
                }
            }
        }
    }

    public void AddQuest(QuestSO quest) //esto lo disparan los npcs cuando les hablo
    {
        Debug.Log("agrego la quest");
        quests.Add(quest);
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
        }
    }
}
