using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestEffector : MonoBehaviour
{
    //apaga y prende gameobjects cuando se dispara el evento de completar una quest

    [SerializeField] List<GameObject> gameObjectsToActivate = new List<GameObject>();
    [SerializeField] List<GameObject> gameObjectsToDeactivate = new List<GameObject>();
    [SerializeField] QuestSO _quest;
    [SerializeField] bool activateOnDeliver; //si no, es onCompleted 


    private void Start()
    {
        if (!activateOnDeliver)
        {
            EventManager.Subscribe(Evento.OnQuestCompleted, Activate);
        }
        else
        {
            EventManager.Subscribe(Evento.OnQuestDelivered, Activate);
        }
    }

    public void Activate(params object[] parameters)
    {
        if ((QuestSO)parameters[0] == _quest) 
        {
            LevelManager.Instance.GameObjectActivator(gameObjectsToActivate, gameObjectsToDeactivate);
        }
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            if (!activateOnDeliver)
            {
                EventManager.Unsubscribe(Evento.OnQuestCompleted, Activate);
            }
            else
            {
                EventManager.Unsubscribe(Evento.OnQuestDelivered, Activate);
            }
        }
    }
}
