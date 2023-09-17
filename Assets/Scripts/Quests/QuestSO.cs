using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Quest", order = 1)]
public class QuestSO : ScriptableObject
{
    public string questName;
    [TextArea] public string questDescription;
    public Condition condition;
    public RewardType rewardType;

    //eventualmente podrian tener un reward,
    //tambien podrian tener un string descripcion de cada condicion
}

[System.Serializable]
public struct Condition
{
    public ConditionType conditionType;
    public ResourceType resourceType;
    public int requiredAmount;
    public Evento evento;
}

public enum ConditionType
{
    Resource,
    Event
}