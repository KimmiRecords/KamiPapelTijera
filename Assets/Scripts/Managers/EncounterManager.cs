using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
    // cuando termina cierto dialogo, spawnea un encounter. eventualmente podria encargarse de todos

    [SerializeField] bool _isDialogueTriggered = true;
    [SerializeField] Dialogue _triggeringDialogue;
    [SerializeField] GameObject _encounter;
    bool firstTime = true;

    void Start()
    {
        EventManager.Subscribe(Evento.OnDialogueEnd, SpawnEncounter);
    }

    public void SpawnEncounter(params object[] parameters)
    {
        if (_isDialogueTriggered && (Dialogue)parameters[1] == _triggeringDialogue && firstTime)
        {
            _encounter.SetActive(true);
            firstTime = false;
            AudioManager.instance.PlayByName("MagicFail", 0.7f);
        }
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnDialogueEnd, SpawnEncounter);

        }
    }
}
