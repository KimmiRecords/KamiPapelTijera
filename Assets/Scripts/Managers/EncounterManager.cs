using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
    // cuando termina cierto dialogo, spawnea un encounter.
    // eventualmente podria encargarse de todos y ser global?
    // o por ahi un manager x encuentro? no se jaja

    [SerializeField] bool _isDialogueTriggered = true;
    [SerializeField] DialogueSO _triggeringDialogue;
    [SerializeField] GameObject _encounter;
    bool firstTime = true;

    void Start()
    {
        EventManager.Subscribe(Evento.OnDialogueEnd, SpawnEncounter);
        EventManager.Subscribe(Evento.OnEncounterEnd, EndEncounter);
        EventManager.Subscribe(Evento.OnRocosoWokeUp, OnRocosoWakesUp);
    }

    public void SpawnEncounter(params object[] parameters)
    {
        if (_isDialogueTriggered && 
            (DialogueSO)parameters[1] == _triggeringDialogue)
        {
            _encounter.SetActive(true);
            AudioManager.instance.PlayByName("MagicFail", 0.5f);
            EventManager.Trigger(Evento.OnEncounterStart, CameraMode.General);
        }
    }

    public void OnRocosoWakesUp(params object[] parameters)
    {
        if (!(bool)parameters[0]) //si no es el boss
        {
            return;
        }

        if (!firstTime)
        {
            return;
        }

        AudioManager.instance.StopByName("MemoFloraMainLoop01");
        AudioManager.instance.PlayByName("MemoFloraBattleLoop01");
        firstTime = false;
    }

    private void EndEncounter(params object[] parameters)
    {
        AudioManager.instance.StopByName("MemoFloraBattleLoop01");
        AudioManager.instance.PlayByName("MemoFloraPostBattle01");
        AudioManager.instance.PlayOnEnd("MemoFloraPostBattle01", "MemoFloraMainLoop01");
        //EventManager.Trigger(Evento.OnEncounterEnd, Camara.Normal);
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnDialogueEnd, SpawnEncounter);
            EventManager.Unsubscribe(Evento.OnEncounterEnd, EndEncounter);
            EventManager.Unsubscribe(Evento.OnRocosoWokeUp, OnRocosoWakesUp);
        }
    }
}
