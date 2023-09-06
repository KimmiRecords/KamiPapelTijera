using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class QuestEffector : MonoBehaviour
{
    //apaga y prende gameobjects cuando se dispara el evento de completar una quest

    [SerializeField] List<GameObject> gameObjectsToActivate = new List<GameObject>();
    [SerializeField] List<GameObject> gameObjectsToDeactivate = new List<GameObject>();
    [SerializeField] QuestSO _quest;

    private void Start()
    {
        EventManager.Subscribe(Evento.OnQuestCompleted, Activate); //esto significa que sucede al completar, no al entregar. pero podria cambiarlo
    }

    public void Activate(params object[] parameters)
    {
        if ((QuestSO)parameters[0] == _quest) 
        {
            foreach (GameObject go in gameObjectsToActivate)
            {
                go.SetActive(true);
            }
            foreach (GameObject go in gameObjectsToDeactivate)
            {
                go.SetActive(false);
            }
        }
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnQuestCompleted, Activate);
        }
    }
}
