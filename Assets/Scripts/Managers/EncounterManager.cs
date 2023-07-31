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
    [SerializeField] Dialogue _triggeringDialogue;
    [SerializeField] GameObject _encounter;
    bool firstTime = true;

    void Start()
    {
        EventManager.Subscribe(Evento.OnDialogueEnd, SpawnEncounter);
        EventManager.Subscribe(Evento.OnEncounterEnd, EndEncounter);
    }

    public void SpawnEncounter(params object[] parameters)
    {
        if (_isDialogueTriggered && (Dialogue)parameters[1] == _triggeringDialogue && firstTime)
        {
            _encounter.SetActive(true);
            firstTime = false;
            AudioManager.instance.PlayByName("MagicFail", 0.7f);
            AudioManager.instance.StopByName("MemoFloraMainLoop01");
            AudioManager.instance.PlayByName("MemoFloraBattleLoop01");
            EventManager.Trigger(Evento.OnEncounterStart, Camara.General);
        }
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

        }
    }
}
